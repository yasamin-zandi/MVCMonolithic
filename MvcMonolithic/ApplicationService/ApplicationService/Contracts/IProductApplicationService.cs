using MvcMonolithic.ApplicationService.Dtos;

namespace MvcMonolithic.ApplicationService.ApplicationService.Contracts
{
    public interface IProductApplicationService
    {

        #region Post

        Task PostProduct(PostProductDto postProductDto);


        #endregion

        #region Edit
        Task EditProduct(EditProductDto editProductDto)    ;
        #endregion

        #region Delete

        Task DeleteProduct(int id);

        #endregion

        #region SelectAll

        Task<List<GetProductDto>> GetAllProducts();
        #endregion

        #region get-by-id
        Task<GetProductDto?> GetProductbyId(int id);
        #endregion

   
    }
     
}
