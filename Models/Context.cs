using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;

namespace TrueNetFinalProject.Models
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<HelpDeskStaff>().HasMany(t => t.Tickets);
            IList<User> userList = new List<User>();

            userList.Add(new User() { UserId = 1, FName = "Justice", LName = "Rose",UserName = "Bones", Password = "testingPassword",Email = "TestingEmail@outlook.com", PhoneNumber = "1406-281-4722"});
            userList.Add(new User() { UserId = 2, FName = "King", LName = "Lowin", UserName = "KingTone", Password = "testingPassword2", Email = "TestingEmail2@outlook.com", PhoneNumber = "1406-281-4745" });

            modelBuilder.Entity<User>().HasData(userList);

            IList<Order> orderList = new List<Order>();

            orderList.Add(new Order() { orderId = 1, customerId = 1, destination = "Testing Warehouse 1", OrderDate = DateTime.Now});
            orderList.Add(new Order() { orderId = 2, customerId = 2, destination = "Testing Warehouse 2", OrderDate = DateTime.Now });

            modelBuilder.Entity<Order>().HasData(orderList);

            IList<Product> productList = new List<Product>();

            productList.Add(new Product() { productId = 1, productName = "Banana", location = "Papa's Banana Emporium", stock = 10 });
            productList.Add(new Product() { productId = 2, productName = "Datapad", location = "Pina'Colada Electronics", stock = 250, fragile = true });
            productList.Add(new Product() { productId = 3, productName = "Printer", location = "Pina'Colada Electronics", stock = 150, fragile = true });
            productList.Add(new Product() { productId = 4, productName = "Laptop", location = "Pina'Colada Electronics", stock = 52, fragile = true });
            productList.Add(new Product() { productId = 5, productName = "Pine 2x4 Pallete", location = "King Tonnage", stock = 35 });

            modelBuilder.Entity<Product>().HasData(productList);

            IList<OrderItem> orderItemList = new List<OrderItem>();

            orderItemList.Add(new OrderItem() { orderId = 1, orderItemId = 1, productId = 2, quantity = 15});
            orderItemList.Add(new OrderItem() { orderId = 1, orderItemId = 2, productId = 4, quantity = 4 });
            orderItemList.Add(new OrderItem() { orderId = 2, orderItemId = 3, productId = 3, quantity = 10 });
            orderItemList.Add(new OrderItem() { orderId = 2, orderItemId = 4, productId = 4, quantity = 2 });
            orderItemList.Add(new OrderItem() { orderId = 2, orderItemId = 5, productId = 1, quantity = 3 });

            modelBuilder.Entity<OrderItem>().HasData(orderItemList);
        }
    }
}
