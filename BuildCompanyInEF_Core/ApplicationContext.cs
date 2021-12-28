using BuildCompanyInEF_Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildCompanyInEF_Core
{
    class ApplicationContext : DbContext
    {
        public DbSet<ConstructionСompany> ConstructionCompanies { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Department> Departments{ get; set; }
        public DbSet<WorkingObject> WorkingObjects{ get; set; }
        public DbSet<Client> Clients{ get; set; }
        public DbSet<Employee> Employees{ get; set; }
        public DbSet<DirectWork> DirectWorks{ get; set; }
        public DbSet<Brigade> Brigades{ get; set; }
        public DbSet<WorkPlan> WorkPlans{ get; set; }
        public DbSet<Equipment> Equipments{ get; set; }
        public DbSet<Working> Workings{ get; set; }

        public IQueryable<Order> GetOrderPrice(int price) => FromExpression(() => GetOrderPrice(price));

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        { 
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDbFunction(() => GetOrderPrice(default));
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<Working>()
                .HasMany(w => w.Brigades)
                .WithMany(b => b.Workings)
                .UsingEntity<WorkPlan>
                (
                j => j
                .HasOne(p => p.Brigade)
                .WithMany(p => p.WorkPlans)
                .HasForeignKey(fk => fk.BrigadeId),
                j => j
                .HasOne(p => p.Working)
                .WithMany(p => p.WorkPlans)
                .HasForeignKey(fk => fk.WorkingId),
                j =>
                {
                    j.Property(pt => pt.DateTimeShift).HasDefaultValueSql("CURRENT_TIMESTAMP");
                    j.HasKey(k => new { k.BrigadeId, k.WorkingId });
                    j.ToTable("WorkPlan");
                }
                );

            modelBuilder.Entity<Order>()
                .HasOne(p => p.Client)
                .WithMany(p => p.Orders)
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
