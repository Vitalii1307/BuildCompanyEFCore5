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
            Client client1 = new Client { Name = "Tom", Surname = "Brown", PhoneNumber = "452331" };
            Client client2 = new Client { Name = "Bob", Surname = "Robson", PhoneNumber = "45564231" };


            Order order1 = new Order { Company = ConstructionCompanyGlobal, Client = client1, ApproximatePrice = 46645, Date = new DateTime(20, 2, 2), Task = "build" };
            Order order2 = new Order { Company = ConstructionCompanyGlobal, Client = client2, ApproximatePrice = 4664, Date = new DateTime(21, 4, 8), Task = "build" };


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

            WorkingObject workingObject1 = new WorkingObject
            {
                InventoryEquipment = "UkrBud",
                Area = "20 m^2",
                Deadline = new DateTime(2022,1,20)
            };

            WorkingObject workingObject2 = new WorkingObject
            {
                InventoryEquipment = "TreeBud",
                Area = "40 m^2",
                Deadline = new DateTime(2022, 7, 10)
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
                Nationality = "urk",
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
            List<Working> workings = new List<Working> { workingBill, workingMike, workingPetya, workingVasya };
            List<DirectWork> directWorks = new List<DirectWork> { directWork1, directWork2 };
            List<Equipment> equipments = new List<Equipment> { equipment1, equipment2, equipment3, equipment4 };

            var optionBuilder = new DbContextOptionsBuilder<ApplicationContext>();

            var options = optionBuilder.UseSqlServer(GetConnectionString()).Options;

            using (ApplicationContext db = new ApplicationContext(options))
            {
                db.ConstructionCompanies.Add(ConstructionCompanyGlobal);
                db.Orders.AddRange(order1, order2);
                db.Departments.Add(department);
                db.WorkingObjects.AddRange(workingObject1, workingObject2);
                db.Clients.AddRange(client1, client2);
                db.Employees.AddRange(employee1, employee2);
                db.DirectWorks.AddRange(directWork1, directWork2);
                db.Brigades.AddRange(brigade1, brigade2);

                brigade1.WorkPlans.Add(new WorkPlan { Working = workingBill, DateTimeShift = new DateTime(2020, 7, 4) });
                brigade1.WorkPlans.Add(new WorkPlan { Working = workingPetya, DateTimeShift = new DateTime(2020, 11, 6) });
                brigade2.WorkPlans.Add(new WorkPlan { Working = workingVasya, DateTimeShift = new DateTime(2020, 10, 7) });
                brigade2.WorkPlans.Add(new WorkPlan { Working = workingMike, DateTimeShift = new DateTime(2020, 11, 2) });

                directWork1.Equipments.Add(equipment1);
                directWork1.Equipments.Add(equipment2);
                directWork2.Equipments.Add(equipment3);
                directWork2.Equipments.Add(equipment4);

                db.SaveChanges();

                Console.WriteLine("Current state");
                foreach (var c in db.Clients.ToList()) Console.WriteLine($"Id - {c.ClientId}: Name - {c.Name}, Surname - {c.Surname}");
                DeleteClientsObjects(db);
                Console.WriteLine("After deleted");
                foreach (var c in db.Clients.ToList()) Console.WriteLine($"Id - {c.ClientId}: Name - {c.Name}, Surname - {c.Surname}");
                Console.WriteLine();
                Console.WriteLine("Current state");
                foreach (var w in db.Workings.ToList()) Console.WriteLine($"Id - {w.WorkingId}: Name - {w.Name}, Surname - {w.Surname}, Nationality - {w.Nationality}");
                UpdateWorkerObjects(db);
                Console.WriteLine("After update");
                foreach (var w in db.Workings.ToList()) Console.WriteLine($"Id - {w.WorkingId}: Name - {w.Name}, Surname - {w.Surname}, Nationality - {w.Nationality}");
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
            var coll = db.Workings.Where(p=>p.Nationality == "ukr");
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
