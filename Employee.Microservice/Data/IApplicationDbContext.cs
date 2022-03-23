using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Microservice.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Entities.Employee> Employees { get; set; }
        Task<int> SaveChanges();
    }
}
