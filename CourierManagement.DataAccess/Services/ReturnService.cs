using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CourierManagement.Core.Models;
using CourierManagement.DataAccess.Data;

namespace CourierManagement.DataAccess.Services
{
    public class ReturnService : IDataService
    {
        public async Task AddToDatabaseAsync(IDataModel model)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                await dbContext.Returns.AddAsync((Return)model).ConfigureAwait(false);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public async Task EditInDatabaseAsync(IDataModel model)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                dbContext.Returns.Update((Return)model);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public Task<IEnumerable<IDataModel>> GetAllFromDatabaseAsync()
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromDatabaseAsync(IDataModel model)
        {
            throw new NotImplementedException();
        }
    }
}
