using MvcMonolithic.Models.DomainModels.ProductType;

namespace MvcMonolithic.Models.Services.Contracts
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategories();
    }
}
