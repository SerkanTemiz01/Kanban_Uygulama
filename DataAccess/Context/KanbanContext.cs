using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class KanbanContext:DbContext
    {
        public KanbanContext():base("server=LAPTOP-H9PBUUIN\\MSSQLSERVER2019;database=To_Do;Trusted_Connection=True;")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Work> Works { get; set; }


    }
}
