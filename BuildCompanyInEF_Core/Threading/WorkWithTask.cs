using BuildCompanyInEF_Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuildCompanyInEF_Core.Threading
{
    class WorkWithTask
    {
        private ApplicationContext db { get; set; }

        private object locker = new object();
        private int count = 0;
        public WorkWithTask(ApplicationContext db)
        {
            this.db = db;
        }

        public void AddedClient(int count)
        {
            List<Thread> threadList = new List<Thread>();

            for (int i = 0; i < count; i++)
                threadList.Add(new Thread(new ParameterizedThreadStart(AddedClientInDataBase)));

            foreach (var item in threadList)
                item.Start(5);


            var allThreadsAreDone1 = false;
            while (!allThreadsAreDone1)
            {
                allThreadsAreDone1 = threadList.All(l => l.ThreadState == ThreadState.Stopped);
            }

        }

        public void AddedClientInDataBase(object param)
        {
            lock (locker)
            {

                for (int i = 0; i < (int)param; i++)
                    {
                        db.Clients.Add(new Client { Name = $"Client - {count}" });
                        db.Orders.Add(new Order { Task = $"Order - {count}" });
                        count++;
                        db.SaveChanges();
                    }
            }
        }

        public void PullOutNames(int count) 
        {
            Thread thread1 = new Thread(new ParameterizedThreadStart(GetNames));

            thread1.Start(count);
            var allThreadsAreDone = false;
            while (!allThreadsAreDone)
            {
                allThreadsAreDone = thread1.ThreadState == ThreadState.Stopped;
            }
        }

        public void GetNames(object count) 
        {
            var clientNames = new List<string>();
            var orderTasks = new List<string>();

            var listClientsNames = db.Clients.Take((int)count).ToList();
            var listOrderTask = db.Orders.Take((int)count).ToList();

            listClientsNames.ForEach(n => clientNames.Add(n.Name.ToString()));
            listOrderTask.ForEach(n => orderTasks.Add(n.Task.ToString()));

            
            foreach (var item in clientNames)
                Console.WriteLine(item);
            foreach (var item in orderTasks)
                Console.WriteLine(item);

        }

        public void LoadDataAsync(int count)
        {
            var task = Task.Run(() => GetNames(count));
            Task.WaitAll(task);
        }

        

        public List<string> GetDataAsync(int count)
        {
            List<string> names = new List<string>();
            LoadDataAsync(count);
            return names;
        }

        public async Task Example_Linq() 
        {
            int sum = 0;

            var client =  await db.Clients.FirstOrDefaultAsync(p => p.ClientId == 1);
            sum = await db.Orders.Where(o => o.Task.Contains("2") == true).CountAsync();

            if (client != null)
            {
                Console.WriteLine(client.Name + "\n");
                Console.WriteLine("Count orders which contains '2': " + sum); ;
            }
        }


        public async Task GetObjectsAsync() 
        {
                await db.Clients.ForEachAsync(p =>
                {
                    Console.WriteLine("{0} ({1})", p.ClientId, p.Name);
                });
            
        }
    }
}
