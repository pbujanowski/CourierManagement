using CourierManagement.Core.Models;
using CourierManagement.DataAccess.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace CourierManagement.DataAccess.Services
{
    /// <summary>
    /// Usługa dla modelu kuriera
    /// </summary>
    public class CourierService : IDataService
    {
        /// <summary>
        /// Asynchroniczne zadanie zwracające kolekcję z wszystkimi kurierami z bazy danych
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<IDataModel>> GetAllFromDatabaseAsync()
        {
            await Task.CompletedTask;
            using (var dbContext = new ApplicationDbContext())
            {
                return dbContext.Couriers.ToList();
            }
        }

        /// <summary>
        /// Asynchroniczne statyczne zadanie dodające nowego kuriera do bazy danych
        /// </summary>
        /// <param name="courier"></param>
        public async Task AddToDatabaseAsync(IDataModel model)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                await dbContext.Couriers.AddAsync((Courier)model).ConfigureAwait(false);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Asynchroniczne statyczne zadanie modyfikujące istniejącego kuriera w bazie danych
        /// </summary>
        /// <param name="courier"></param>
        public async Task EditInDatabaseAsync(IDataModel model)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                dbContext.Couriers.Update((Courier)model);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Asynchroniczne statyczne zadanie usuwające istniejącego kuriera z bazy danych
        /// </summary>
        /// <param name="courier"></param>
        public async Task RemoveFromDatabaseAsync(IDataModel model)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                dbContext.Couriers.Remove((Courier)model);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
        }
    }
}