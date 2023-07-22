using SPServiceCRUDApp.Models;
using System.Data.Entity;


namespace SPServiceCRUDApp.Data
{
    public class CRUDAppContext : DbContext
    {
        public CRUDAppContext() : base("name=CRUDAppContext")
        {
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
