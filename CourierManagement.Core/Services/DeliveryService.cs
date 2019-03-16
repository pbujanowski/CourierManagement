using CourierManagement.Core.Data;
using CourierManagement.Core.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
            using (var dbContext = new ApplicationDbContext())
            {
                var data = (from deliveries in dbContext.Deliveries
                            join senders in dbContext.Senders on deliveries.SenderId equals senders.Id
                            join recipients in dbContext.Recipients on deliveries.RecipientId equals recipients.Id
                            select new Delivery
                            {
                                Id = deliveries.Id,
                                SenderId = senders.Id,
                                Sender = deliveries.Sender,
                                RecipientId = recipients.Id,
                                Recipient = deliveries.Recipient,
                                SentDate = deliveries.SentDate,
                                ReceivedDate = deliveries.ReceivedDate,
                                Cost = deliveries.Cost,
                                PaymentType = deliveries.PaymentType,
                                Length = deliveries.Length,
                                Width = deliveries.Width,
                                Height = deliveries.Height,
                                IsFragile = deliveries.IsFragile
                            }).ToList();
                return data;
            }
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