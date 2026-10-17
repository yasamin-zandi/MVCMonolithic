using Microsoft.EntityFrameworkCore;
using MvcMonolithic.Models.DomainModels.ProductType;
using MvcMonolithic.Models.Services.Contracts;

namespace MvcMonolithic.Models.Services.Repository
{
    public class CategoryRepository : ICategoryRepository

    {
        private readonly ProjectDbContext _projectDbContext;
        public CategoryRepository(ProjectDbContext projectDbContext)
        {
            _projectDbContext = projectDbContext;
        }
        public async Task<List<Category>> GetAllCategories()
        {
            return await _projectDbContext.Category.ToListAsync();
        }
    }
}
