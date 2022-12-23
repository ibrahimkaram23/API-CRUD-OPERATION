using System;
using System.Data.Entity;
using System.Linq;

namespace API_CRUD_OPERATION.Models
{
    public class CompanyDBContext : DbContext
    {
        
        public CompanyDBContext()
            : base("name=CompanyDBContext")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}