using CourierManagement.Core.Data;
using CourierManagement.Core.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CourierManagement.Core.Services
{
    public class DeliveryService : IDataService
    {
        /// <summary>
        /// Asynchroniczne statyczne zadanie pobierające wszystkie przesyłki z bazy danych
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<IDataModel>> GetAllFromDatabaseAsync()
        {
            await Task.CompletedTask;
            //return AllDeliveries();
            var data = new ObservableCollection<Delivery>();
            using (var dbContext = new ApplicationDbContext())
            {
                foreach (var item in dbContext.Deliveries)
                    data.Add(item);
            }
            return data;
        }

        /// <summary>
        /// Asynchroniczne statyczne zadanie dodające nową przesyłkę do bazy danych
        /// </summary>
        /// <param name="delivery"></param>
        /// <returns></returns>
        public async Task AddToDatabaseAsync(IDataModel model)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                await dbContext.Deliveries.AddAsync((Delivery)model).ConfigureAwait(false);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Asynchroniczne statyczne zadanie modyfikujące przesyłkę w bazie danych
        /// </summary>
        /// <param name="delivery"></param>
        /// <returns></returns>
        public async Task EditInDatabaseAsync(IDataModel model)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                dbContext.Deliveries.Update((Delivery)model);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Asynchroniczne statyczne zadanie usuwające przesyłkę z bazy danych
        /// </summary>
        /// <param name="delivery"></param>
        /// <returns></returns>
        public async Task RemoveFromDatabaseAsync(IDataModel model)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                dbContext.Deliveries.Remove((Delivery)model);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
        }
    }
}