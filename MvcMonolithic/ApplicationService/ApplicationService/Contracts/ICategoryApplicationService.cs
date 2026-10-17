using MvcMonolithic.ApplicationService.Dtos;

namespace MvcMonolithic.ApplicationService.ApplicationService.Contracts
{
    public interface ICategoryApplicationService
    {

        #region Select all category
        Task<List<GetCategoryDto>> GetCategoriesSelectList();
        #endregion
    }
}
