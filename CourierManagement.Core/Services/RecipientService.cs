using CourierManagement.Core.Data;
using CourierManagement.Core.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace CourierManagement.Core.Services
{
    public class RecipientService : IDataService
    {
        /// <summary>
        /// Asynchroniczne statyczne zadanie pobierające wszystkich odbiorców z bazy danych
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<IDataModel>> GetAllFromDatabaseAsync()
        {
            await Task.CompletedTask;
            using (var dbContext = new ApplicationDbContext())
            {
                return dbContext.Recipients.ToList();
            }
        }

        /// <summary>
        /// Asynchroniczne statyczne zadanie dodające nowego odbiorcę do bazy danych
        /// </summary>
        /// <param name="recipient"></param>
        /// <returns></returns>
        public async Task AddToDatabaseAsync(IDataModel model)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                await dbContext.Recipients.AddAsync((Recipient)model).ConfigureAwait(false);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Asynchroniczne statyczne zadanie modyfikujące odbiorcę w bazie danych
        /// </summary>
        /// <param name="recipient"></param>
        /// <returns></returns>
        public async Task EditInDatabaseAsync(IDataModel model)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                dbContext.Recipients.Update((Recipient)model);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Asynchroniczne statyczne zadanie usuwające odbiorcę z bazy danych
        /// </summary>
        /// <param name="recipient"></param>
        /// <returns></returns>
        public async Task RemoveFromDatabaseAsync(IDataModel model)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                dbContext.Recipients.Remove((Recipient)model);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
        }
    }
}