namespace WebApplication3
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Factory : DbContext
    {
        public Factory()
            : base("name=Model1")
        {
            Database.SetInitializer<Factory>(new CustomInit<Factory>());
        }

        public virtual DbSet<Worker> Workers { get; set; }
    }

    public class Worker
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
        public string Gedner { get; set; }

    }
}