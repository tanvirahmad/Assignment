using Employee.Microservice.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Microservice.Data
{
    public class ApplicationDbContext : DbContext,IApplicationDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Entities.Employee> Employees{ get; set; }

        public async Task<int> SaveChanges()
        {
            try
            {

                return await base.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
