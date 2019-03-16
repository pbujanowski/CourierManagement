using CourierManagement.Core.Data;
using CourierManagement.Core.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace CourierManagement.Core.Services
{
    public class SenderService : IDataService
    {
        /// <summary>
        /// Asynchroniczne statyczne zadanie pobierające wszystkich nadawców z bazy danych
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<IDataModel>> GetAllFromDatabaseAsync()
        {
            await Task.CompletedTask;
            using (var dbContext = new ApplicationDbContext())
            {
                return dbContext.Senders.ToList();
            }
        }

        /// <summary>
        /// Asynchroniczne statyczne zadanie dodające nowego nadawcę do bazy danych
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public async Task AddToDatabaseAsync(IDataModel model)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                await dbContext.Senders.AddAsync((Sender)model).ConfigureAwait(false);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Asynchroniczne statyczne zadanie modyfikujące nadawcę w bazie danych
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public async Task EditInDatabaseAsync(IDataModel model)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                dbContext.Senders.Update((Sender)model);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Asynchroniczne statyczne zadanie usuwające nadawcę z bazy danych
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task RemoveFromDatabaseAsync(IDataModel model)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                dbContext.Senders.Remove((Sender)model);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
        }
    }
}