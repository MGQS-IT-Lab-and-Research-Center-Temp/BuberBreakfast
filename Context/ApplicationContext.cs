using BuberBreakfast.Entities;
using Microsoft.EntityFrameworkCore;

namespace BuberBreakfast.Context
{
    public class ApplicationContext : DbContext
    {
       public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) 
        {

        }
         public DbSet<BreakFast> BreakFasts { get; set; }
    }
}
 