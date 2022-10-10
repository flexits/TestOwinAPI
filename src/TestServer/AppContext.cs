using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestServer
{
    //Database layer

    public class AppContext : DbContext
    {
        public AppContext() : base("TSContext") { }
        public DbSet<Customer> Customers { get; set; }          //client info
        public DbSet<Product> Products { get; set; }            //product info
        public DbSet<Status> Statuses { get; set; }             //available order statuses
        public DbSet<Order> Orders { get; set; }                //orders list
        public DbSet<Advance> Advances { get; set; }            //records of items added into inventory
        public DbSet<Withdrawal> Withdrawals { get; set; }      //records of items withdrawn from inventory
    }

    public class Customer
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }

    public class Product
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
    }

    [Table("Statuses")]
    public class Status
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
    }

    public class Order
    {
        [Key]
        public int id { get; set; }
        public int Cust_id { get; set; }
        public int Status_id { get; set; }
    }

    public class Advance
    {
        [Key]
        public int id { get; set; }
        public int Doc_id { get; set; }
        public int Prod_id { get; set; }
        public int Amount { get; set; }
    }

    public class Withdrawal
    {
        [Key]
        public int id { get; set; }
        public int Order_id { get; set; }
        public int Prod_id { get; set; }
        public int Amount { get; set; }
    }
}
