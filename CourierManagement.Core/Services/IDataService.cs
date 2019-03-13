using CourierManagement.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourierManagement.Core.Services
{
    public interface IDataService
    {
        Task AddToDatabaseAsync(IDataModel model);

        Task<IEnumerable<IDataModel>> GetAllFromDatabaseAsync();

        Task EditInDatabaseAsync(IDataModel model);

        Task RemoveFromDatabaseAsync(IDataModel model);
    }
}