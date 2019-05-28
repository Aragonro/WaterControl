using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoterCantrol.DAL.Entities;

namespace WoterCantrol.DAL.EF
{
    public class WaterControlContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<NewOrder> NewOrders { get; set; }
        public DbSet<Monitoring> Monitorings { get; set; }
        public DbSet<DeliverySetting> DeliverySettings { get; set; }
        public DbSet<Statistic> Statistics { get; set; }

        static WaterControlContext()
        {
            Database.SetInitializer<WaterControlContext>(new StoreDbInitializer());
        }
        public WaterControlContext(string connectionString)
            : base(connectionString)
        {
        }
        public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<WaterControlContext>
        {
            protected override void Seed(WaterControlContext db)
            {
                db.Users.Add(new User { Email = "vitalii.batiuchenko@nure.ua", FirstName = "Vitalii", SecondName = "Batiuchenko", Passport = "ХА355125", Phone="0987100133", Role = "Admin"});
                db.Users.Add(new User { Email = "user1@nure.ua", FirstName = "Name1", SecondName = "SecondName1", Passport = "ХА123456", Phone = "09811111111", Role = "User" });
                db.Products.Add(new Product { Name = "5 gal", Count = 15, Price = 25, Weight = 20 });
                var user = db.Users.First(i => i.Role == "User");
                var product = db.Products.First();
                db.Sensors.Add(new Sensor { CountProduct = 1, DelivaryAddress = "пр. Науки 14", UserId = user.Id, IsWorking = false, ProductId = product.Id, UseAutomaticDelivery = false });
                db.SaveChanges();
            }
        }
    }
}