using MvcMonolithic.ApplicationService.Dtos;
using MvcMonolithic.Models.DomainModels.PersonAggregates;

namespace MvcMonolithic.ApplicationService.ApplicationService.Contracts
{
    public interface IPersonApplicationService
    {

        #region get-by-id
        Task<EditPersonDto?> GetbyId(int id);
        #endregion

        #region Update

        Task Update(EditPersonDto dto);
        #endregion

        #region Post
        Task PostPerson(PostPersonDto postPersonDto);

        #endregion

        #region Delete
        Task RemovePerson(int id); 
        #endregion

        #region Get all
        Task<List<GetPersonDto>> GetAllPeople();
        #endregion
    }
}
