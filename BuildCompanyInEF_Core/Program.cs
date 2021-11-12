using BuildCompanyInEF_Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BuildCompanyInEF_Core
{
    class Program
    {
        static void Main(string[] args)
        {
            ConstructionСompany ConstructionCompanyGlobal = new ConstructionСompany { CompanyName = "Savchuk Global Build", Address = "ул. Пушкина", Email = "global_build@gmail.com", Owner = "Вася Бос", PhoneNumber = "0965697654", USREOUCode = 1230000 };

            Department department = new Department
            {
                ConstructionCompany = ConstructionCompanyGlobal,
                Email = "dep1@gmail.com",
                NameDepartment = "Отдел кадров",
                PhoneNumber = "456132",
                Specialization = "Search worker"
            };
            Client client1 = new Client { Name = "Mike", Surname = "Brown", PhoneNumber = "452331" };
            Client client2 = new Client { Name = "Mike", Surname = "Robson", PhoneNumber = "45564231" };
            Client client3 = new Client { Name = "John", Surname = "Smith", PhoneNumber = "45568761" };
            Client client4 = new Client { Name = "Mike", Surname = "Thomson", PhoneNumber = "45568761" };
            Client client5 = new Client { Name = "Petr", Surname = "Chech", PhoneNumber = "4752761" };

            WorkingObject workingObject1 = new WorkingObject
            {
                InventoryEquipment = "UkrBud",
                Area = "20 m^2",
                Deadline = new DateTime(2022, 1, 20)
            };

            WorkingObject workingObject2 = new WorkingObject
            {
                InventoryEquipment = "TreeBud",
                Area = "40 m^2",
                Deadline = new DateTime(2022, 7, 10)
            };


            Order order1 = new Order { Company = ConstructionCompanyGlobal, Client = client1, ApproximatePrice = 46645, Date = new DateTime(20, 2, 2), Task = "build ", WorkingObject = workingObject1 };
            Order order2 = new Order { Company = ConstructionCompanyGlobal, Client = client1, ApproximatePrice = 50000, Date = new DateTime(21, 4, 8), Task = "build", WorkingObject = workingObject1 };
            Order order3 = new Order { Company = ConstructionCompanyGlobal, Client = client1, ApproximatePrice = 2000, Date = new DateTime(21, 4, 8), Task = "build", WorkingObject = workingObject1 };
            Order order4 = new Order { Company = ConstructionCompanyGlobal, Client = client2, ApproximatePrice = 8000, Date = new DateTime(21, 4, 8), Task = "build", WorkingObject = workingObject2 };
            Order order5 = new Order { Company = ConstructionCompanyGlobal, Client = client3, ApproximatePrice = 5500, Date = new DateTime(21, 4, 8), Task = "build", WorkingObject = workingObject2 };


            Employee employee1 = new Employee
            {
                Name = "Nicolas",
                Surname = "Cage",
                Position = "Ofice worker",
                PhoneNumber = "45632564",
                Email = "NK1@gmail.com",
                Birthday = new DateTime(1964, 1, 7),
                Department = department,
                IdentificationCode = 10224,
                Salary = 1000,
            };
            Employee employee2 = new Employee
            {
                Name = "Leonardo",
                Surname = "DiCaprio",
                Position = "Ofice worker",
                PhoneNumber = "45632574",
                Email = "LD1@gmail.com",
                Birthday = new DateTime(1974, 11, 11),
                Department = department,
                IdentificationCode = 10524,
                Salary = 1100,
            };

           


            Brigade brigade1 = new Brigade
            {
                WorkingDays = "pairs",
                WorkShift = "mon, tue, fr"
            };

            Brigade brigade2 = new Brigade
            {
                WorkingDays = "not pairs",
                WorkShift = "wed, thu, sat"
            };

            Working workingBill = new Working
            {
                Name = "Bil",
                Surname = "Clinton",
                IdentificationCode = 10001,
                Nationality = "ukr",
                Specialty = "builder",
                PhoneNumber = 0965698546,
                Salary = 1000
            };

            Working workingMike = new Working
            {
                Name = "Mike",
                Surname = "Posner",
                IdentificationCode = 10002,
                Nationality = "eng",
                Specialty = "builder",
                PhoneNumber = 0967538546,
                Salary = 1450
            };

            Working workingPetya = new Working
            {
                Name = "Petya",
                Surname = "Kravchenko",
                IdentificationCode = 10003,
                Nationality = "ukr",
                Specialty = "builder",
                PhoneNumber = 0967964546,
                Salary = 1500
            };

            Working workingVasya = new Working
            {
                Name = "Vasya",
                Surname = "Pavlenko",
                IdentificationCode = 10004,
                Nationality = "ukr",
                Specialty = "builder",
                PhoneNumber = 0967404546,
                Salary = 1250
            };

            Working workingKolya = new Working
            {
                Name = "Kolya",
                Surname = "Petrov",
                IdentificationCode = 10005,
                Nationality = "blr",
                Specialty = "builder",
                PhoneNumber = 0967783546,
                Salary = 1450
            };

            Working workingSasha = new Working
            {
                Name = "Sasha",
                Surname = "Mots",
                IdentificationCode = 10006,
                Nationality = "fin",
                Specialty = "builder",
                PhoneNumber = 0969613546,
                Salary = 1100
            };

            Working workingRoma = new Working
            {
                Name = "Roma",
                Surname = "Smith",
                IdentificationCode = 10007,
                Nationality = "eng",
                Specialty = "builder",
                PhoneNumber = 0979343546,
                Salary = 2000
            };
            
            DirectWork directWork1 = new DirectWork
            {
                NameWork = "pouring cement",
                Brigade = brigade1,
                DateFrom = new DateTime(2022, 1, 15),
                DateTo = new DateTime(2022, 6, 15),
                Order = order1,
                PriceOf = 20000
            };

            DirectWork directWork2 = new DirectWork
            {
                NameWork = "work with roof",
                Brigade = brigade2,
                DateFrom = new DateTime(2022, 2, 14),
                DateTo = new DateTime(2022, 8, 21),
                Order = order1,
                PriceOf = 20000
            };

            Equipment equipment1 = new Equipment { Name = "Drill mixer", Model = "Dnipro-M BM-140S", Manufacturer = "Dnipro-M", SerialNumber = 16958000 };
            Equipment equipment2 = new Equipment { Name = "Laser level", Model = "Dnipro-M ML-230", Manufacturer = "Dnipro-M", SerialNumber = 81517000 };
            Equipment equipment3 = new Equipment { Name = "Drill", Model = "Rebir IE-1305A-16", Manufacturer = "Rebir", SerialNumber = 81517431 };
            Equipment equipment4 = new Equipment { Name = "Drill", Model = "Rebir EM1-950E2", Manufacturer = "Rebir", SerialNumber = 81117473 };


            List<Client> clients = new List<Client> { client1, client2 };
            List<Order> orders = new List<Order> { order1, order2 };
            List<Employee> employees = new List<Employee> { employee1, employee2 };
            List<WorkingObject> workingObjects = new List<WorkingObject> { workingObject1, workingObject2 };
            List<Brigade> brigades = new List<Brigade> { brigade1, brigade2 };
            List<Working> workings = new List<Working> { workingBill, /*workingMike,*/ workingPetya, workingVasya };
            List<DirectWork> directWorks = new List<DirectWork> { directWork1, directWork2 };
            List<Equipment> equipments = new List<Equipment> { equipment1, equipment2, equipment3, equipment4 };

            var optionBuilder = new DbContextOptionsBuilder<ApplicationContext>();

            var options = optionBuilder.UseSqlServer(GetConnectionString()).Options;

            //using (ApplicationContext db = new ApplicationContext(options))
            //{
            //    db.ConstructionCompanies.Add(ConstructionCompanyGlobal);
            //    db.Orders.AddRange(order1, order2, order3, order4, order5);
            //    db.Departments.Add(department);
            //    db.WorkingObjects.AddRange(workingObject1, workingObject2);
            //    db.Clients.AddRange(client1, client2, client3);
            //    db.Employees.AddRange(employee1, employee2);
            //    db.DirectWorks.AddRange(directWork1, directWork2);
            //    db.Brigades.AddRange(brigade1, brigade2);

            //    brigade1.WorkPlans.Add(new WorkPlan { Working = workingBill, DateTimeShift = new DateTime(2020, 7, 4) });
            //    brigade1.WorkPlans.Add(new WorkPlan { Working = workingPetya, DateTimeShift = new DateTime(2020, 11, 6) });
            //    brigade1.WorkPlans.Add(new WorkPlan { Working = workingKolya, DateTimeShift = new DateTime(2020, 12, 6) });
            //    brigade1.WorkPlans.Add(new WorkPlan { Working = workingSasha, DateTimeShift = new DateTime(2019, 9, 6) });
            //    brigade2.WorkPlans.Add(new WorkPlan { Working = workingVasya, DateTimeShift = new DateTime(2020, 10, 7) });
            //    brigade2.WorkPlans.Add(new WorkPlan { Working = workingMike, DateTimeShift = new DateTime(2020, 11, 2) });
            //    brigade2.WorkPlans.Add(new WorkPlan { Working = workingRoma, DateTimeShift = new DateTime(2018, 11, 2) });

            //    directWork1.Equipments.Add(equipment1);
            //    directWork1.Equipments.Add(equipment2);
            //    directWork2.Equipments.Add(equipment3);
            //    directWork2.Equipments.Add(equipment4);

            //    db.SaveChanges();


            //    //Console.WriteLine("Current state");
            //    //foreach (var c in db.Clients.ToList()) Console.WriteLine($"Id - {c.ClientId}: Name - {c.Name}, Surname - {c.Surname}");
            //    //DeleteClientsObjects(db);
            //    //Console.WriteLine("After deleted");
            //    //foreach (var c in db.Clients.ToList()) Console.WriteLine($"Id - {c.ClientId}: Name - {c.Name}, Surname - {c.Surname}");
            //    //Console.WriteLine();
            //    //Console.WriteLine("Current state");
            //    //foreach (var w in db.Workings.ToList()) Console.WriteLine($"Id - {w.WorkingId}: Name - {w.Name}, Surname - {w.Surname}, Nationality - {w.Nationality}");
            //    //UpdateWorkerObjects(db);
            //    //Console.WriteLine("After update");
            //    //foreach (var w in db.Workings.ToList()) Console.WriteLine($"Id - {w.WorkingId}: Name - {w.Name}, Surname - {w.Surname}, Nationality - {w.Nationality}");
            //}

            //ExecQueryOnLinq(options);
            //Console.WriteLine();

            //ExecQueryLinqSort(options);
            //Console.WriteLine();

            //ExecJoin(options);
            //Console.WriteLine();

            ExecGroupBy(options);
            //Console.WriteLine();

            //ExecUnionIntersectExcept(options);
            //Console.WriteLine();

            //ExecUnionIntersectExcept(options);
            //Console.WriteLine();

            //ExecAnyAll(options);
            //Console.WriteLine();

            //ExecAgregateOperation(options);
            //Console.WriteLine();

            //ExecStoredFunction(options);
            //Console.WriteLine();

            //ExecStoredProcedore(options);
        }

        static public void ExecQueryOnLinq(DbContextOptions<ApplicationContext> options)
        {
            using (ApplicationContext db = new ApplicationContext(options))
            {
                var equip = db.Equipments.Where(p => p.Name == "Drill");
                Console.WriteLine("Equipment");
                foreach (var e in equip)
                {
                    Console.WriteLine($"Name: {e.Name}, Model: {e.Model}, Manufacturer: {e.Manufacturer}");
                }
            }
            Console.WriteLine();
            using (ApplicationContext db = new ApplicationContext(options))
            {
                var work = db.Workings.Where(w => EF.Functions.Like(w.Name, "%Mi%"));
                Console.WriteLine("Workings");
                foreach (var w in work)
                    Console.WriteLine($"Name: {w.Name}, Surname: {w.Surname}, Selery: {w.Salary}");
            }
            Console.WriteLine();
            using (ApplicationContext db = new ApplicationContext(options))
            {
                var work = db.Workings.Find(3);
                Console.WriteLine($"Worker\nName - {work.Name}, Surname - {work.Surname}");
            }
        }

        static public void ExecQueryLinqSort(DbContextOptions<ApplicationContext> options)
        {
            using (ApplicationContext db = new ApplicationContext(options))
            {
                var eq = db.Equipments.Where(p => EF.Functions.Like(p.Name, "%Dr%")).Select(p => new
                {
                    Name = p.Name,
                    Model = p.Model
                });

                Console.WriteLine("Anonious class");
                foreach (var e in eq)
                    Console.WriteLine($"Name: {e.Name}, Surname: {e.Model}");
            }
            Console.WriteLine();
            using (ApplicationContext db = new ApplicationContext(options))
            {
                var works = from w in db.Workings
                            orderby w.Salary
                            select w;
                Console.WriteLine("Workers");
                foreach (var w in works)
                    Console.WriteLine($"Name: {w.Name}, Salary: {w.Salary}");
            }
        }

        static public void ExecJoin(DbContextOptions<ApplicationContext> options)
        {
            using (ApplicationContext db = new ApplicationContext(options))
            {

                var clients = db.Clients.Join(db.Orders,
                    c => c.ClientId, o => o.ClientId, (c, o) => new
                    {
                        Name = c.Name,
                        Surname = c.Surname,
                        Task = o.Task
                    });
                Console.WriteLine("Clients");
                foreach (var c in clients)
                {
                    Console.WriteLine($"Name: {c.Name}, Surname: {c.Surname}, Task: {c.Task}");
                }

            }

            using (ApplicationContext db = new ApplicationContext(options))
            {
                var list = from c in db.Clients
                           join o in db.Orders on c.ClientId equals o.ClientId
                           join com in db.ConstructionCompanies on o.Company.ConstructionСompanyId equals com.ConstructionСompanyId
                           select new
                           {
                               Name = c.Name,
                               Surname = c.Surname,
                               Task = o.Task,
                               Company = com.CompanyName
                           };
                Console.WriteLine();
                Console.WriteLine("Example join with three entities");
                foreach (var l in list)
                    Console.WriteLine($"Name: {l.Name}, Surname: {l.Surname}, Task: {l.Task}, Company: {l.Company}");
            }
        }

        static public void ExecGroupBy(DbContextOptions<ApplicationContext> options)
        {
            using (ApplicationContext db = new ApplicationContext(options))
            {
                /*var list = from or in db.Orders
                           group or by or.Client.Name into g
                           select new
                           {
                               g.Key,
                               Count = g.Count()
                           };
                Console.WriteLine("Example group order by client name");
                foreach (var l in list)
                    Console.WriteLine($"Client name: {l.Key}, Count order: {l.Count}");

                Console.WriteLine();

                var list2 = from or in db.Orders
                            group or by or.WorkingObject.WorkingObjectId into g
                            select new
                            {
                                g.Key
                            };
                */
                var list = db.Orders.GroupBy(w => w.WorkingObject.WorkingObjectId)
                    .Select(g => new
                    {
                        g.Key,
                        Sum = g.Sum(x => x.ApproximatePrice)
                    })

                var list2 = db.Orders.GroupBy(w => w.WorkingObject.WorkingObjectId)
                    .Select(g => new
                    {
                        g.Key,
                        Sum = g.Sum(x => x.ApproximatePrice)
                    }).OrderByDescending(g => g.Sum).Take(1);

                foreach (var l in list)
                    Console.WriteLine($"Id working obj: {l.Key}, Sum: {l.Sum}");
               
                //var maxPrice = db.Orders.GroupBy(w => w.WorkingObject.WorkingObjectId)
                //    .Select(g => new
                //    {
                //        g.Key,
                //        Sum = g.Sum(x=>x.ApproximatePrice)
                //    }).Max(g=>g.Sum);

                //Console.WriteLine($"Max price of working obj: {maxPrice}");



               
                
            }

           /* using (ApplicationContext db = new ApplicationContext(options))
            {
                var list = from wp in db.WorkPlans
                           join br in db.Brigades on wp.BrigadeId equals br.BrigadeId
                           join wor in db.Workings on wp.WorkingId equals wor.WorkingId
                           group wor by br.BrigadeId into g
                           select new
                           {
                               g.Key,
                              Count = g.Count()
                           };
                Console.WriteLine();
                Console.WriteLine("Example group worker by id brigade");
                foreach (var i in list)
                    Console.WriteLine($"Id brigade: {i.Key}, Count worker: {i.Count}");
                
            }*/
        }

        static public void ExecUnionIntersectExcept(DbContextOptions<ApplicationContext> options) 
        {
            using (ApplicationContext db = new ApplicationContext(options))
            {
                var listUnion = db.Workings.Where(p => p.Salary > 1000).Select(p => new { Name = p.Name })
                    .Union(db.ConstructionCompanies.Select(p => new { Name = p.CompanyName }));
                Console.WriteLine("Names:");
                foreach (var l in listUnion)
                    Console.WriteLine(l.Name);


                var listInterExcept = db.Workings.Where(p => p.Name == "Mike")
                    .Intersect(db.Workings.Where(p => p.Salary > 1000));
                Console.WriteLine();
                Console.WriteLine("Names which have salary more than 1000:");
                foreach (var l in listInterExcept)
                    Console.WriteLine($"Name: {l.Name}, Salary: {l.Salary}");


                var selector1 = db.Workings.Where(p => p.Name == "Mike");
                var selector2 = db.Workings.Where(p => p.Salary >= 2000);

                var resultList = selector1.Except(selector2);
                Console.WriteLine();
                Console.WriteLine("Worker which are int selector1 but which are not int selector 2");
                foreach (var l in resultList)
                    Console.WriteLine($"Name: {l.Name}, Salary: {l.Salary}");
            }

            
        }


        static public void ExecAnyAll(DbContextOptions<ApplicationContext> options) 
        {
            using (ApplicationContext db = new ApplicationContext(options))
            {
                bool result = db.Workings.Any(p => p.Nationality == "ukr");
                if (result)
                    Console.WriteLine("Table Workings has ukr");
                else
                    Console.WriteLine("Table Workings has't ukr");
                Console.WriteLine();
            }

            using (ApplicationContext db = new ApplicationContext(options))
            {                
                bool result = db.Workings.All(p=>p.Specialty == "builder");

                if (result == true)
                    Console.WriteLine("All fields in table Workings has builder");
                else
                    Console.WriteLine("All fields in table Workings has't builder");
            }
        }

        static public void ExecAgregateOperation(DbContextOptions<ApplicationContext> options) 
        {
            using (ApplicationContext db = new ApplicationContext(options))
            {
                int count = db.Workings.Count(w => w.Nationality == "ukr");
                Console.WriteLine($"Count ukrainian workers: {count}");

                int maxSalary = db.Workings.Max(w => w.Salary);
                Console.WriteLine($"Max salary of workers: {maxSalary}");

                double AvgSalary = db.Workings.Average(w => w.Salary);
                Console.WriteLine($"Average salary of workers: {AvgSalary}");

                int sumSalary = db.Workings.Sum(w => w.Salary);
                Console.WriteLine($"Sum everything salary of workers: {sumSalary}");
            }
        }

        static public void ExecStoredFunction(DbContextOptions<ApplicationContext> options) 
        {
            using (ApplicationContext db = new ApplicationContext(options))
            {
                var orders = db.GetOrderPrice(10000);
                foreach (var o in orders)
                    Console.WriteLine($"Id:{o.OrderId} - Price:{o.ApproximatePrice} - Task: {o.Task}");
            }
        }

        static public void ExecStoredProcedore(DbContextOptions<ApplicationContext> options) 
        {
            using (ApplicationContext db = new ApplicationContext(options))
            {
                Microsoft.Data.SqlClient.SqlParameter param = new Microsoft.Data.SqlClient.SqlParameter("@price", 10000);
                var orders = db.Orders.FromSqlRaw("OrderProcedure @price", param).ToList();

                foreach (var o in orders)
                    Console.WriteLine($"Id: {o.OrderId}, Price: {o.ApproximatePrice}, Task: {o.Task}");
            }
        }


        public static void DeleteClientsObjects(ApplicationContext db)
        {
            var client = db.Clients.FirstOrDefault();
            db.Clients.Remove(client);
            db.SaveChanges();
        }

        public static void UpdateWorkerObjects(ApplicationContext db)
        {
            var coll = db.Workings.Where(p => p.Nationality == "ukr");
            var worker = db.Workings.FirstOrDefault();
            if (worker != null)
            {
                worker.Salary = 5000;
                worker.Nationality = "us";
                db.SaveChanges();
            }

        }

        public static string GetConnectionString()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");

            var config = builder.Build();

            return config.GetConnectionString("DefaultConnection");
        }
    }
}
