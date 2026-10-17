using Microsoft.EntityFrameworkCore;
using MvcMonolithic.Models.DomainModels.PersonAggregates;
using MvcMonolithic.Models.DomainModels.ProductAggregates;
using MvcMonolithic.Models.DomainModels.ProductType;

namespace MvcMonolithic.Models
{
    public class ProjectDbContext:DbContext    
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
        {

        }
        public DbSet<Person> Person { get; set; }
        //اسم جداول جمع می باشد.=> مهم
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }


    }
}
