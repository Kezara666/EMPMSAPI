
using Microsoft.EntityFrameworkCore;
using EMPMS_API.Data.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Employee.Data
{
    public class EMSContext : DbContext
    {
        public EMSContext(DbContextOptions options) : base(options)
        {

        }
        
        public DbSet<EmployeeData> Employee { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }



    }
}
