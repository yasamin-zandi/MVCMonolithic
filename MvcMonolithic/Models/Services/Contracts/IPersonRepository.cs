using MvcMonolithic.Models.DomainModels.PersonAggregates;
using MvcMonolithic.Models.DomainModels.PersonAggregates;

namespace MvcMonolithic.Models.Services.Contracts
{
    public interface IPersonRepository
    {

        #region Insert
        Task Insert(Person person);
        #endregion

        #region Select-By-Id
        Task<Person?> SelectbyId(int id);
        #endregion

        #region Update
        Task Update(Person person);
        #endregion

        #region Delete
        Task Delete(int id);
        Task Delete( Person person);
        #endregion

        #region selectAll
        Task<List<Person>> SelectAll();
        #endregion
    }

}
