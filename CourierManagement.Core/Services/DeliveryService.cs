using CourierManagement.Core.Data;
using CourierManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.Core.Services
{
    public static class DeliveryService
    {
        private static IEnumerable<Delivery> AllDeliveries()
        {
            var data = new ObservableCollection<Delivery>()
            {
                new Delivery
                {
                    Id = 1,
                    Sender = new Sender
                    {
                        Company = "Firma nadawcza nr 1"
                    },
                    Recipient = new Recipient
                    {
                        Company = "Firma odbiorcza nr 1"
                    },
                    SentDate = new DateTime(2019,3,8)
                },
                new Delivery
                {
                    Id = 2,
                    Sender = new Sender
                    {
                        Company = "Firma nadawcza nr 2"
                    },
                    Recipient = new Recipient
                    {
                        Company = "Firma odbiorcza nr 2"
                    },
                    SentDate = new DateTime(2019,3,9)
                }
            };
            return data;
        }
        /// <summary>
        /// Asynchroniczne statyczne zadanie pobierające wszystkie przesyłki z bazy danych
        /// </summary>
        /// <returns></returns>
        public static async Task<IEnumerable<Delivery>> GetDeliveriesAsync()
        {
            await Task.CompletedTask;
            return AllDeliveries();
            //var data = new ObservableCollection<Delivery>();
            //using (var dbContext = new ApplicationDbContext())
            //{
            //    foreach (var item in dbContext.Deliveries)
            //        data.Add(item);
            //}
            //return data;
        }
        /// <summary>
        /// Asynchroniczne statyczne zadanie dodające nową przesyłkę do bazy danych
        /// </summary>
        /// <param name="delivery"></param>
        /// <returns></returns>
        public static async Task AddDeliveryAsync(Delivery delivery)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                await dbContext.Deliveries.AddAsync(delivery);
                await dbContext.SaveChangesAsync();
            }
        }
        /// <summary>
        /// Asynchroniczne statyczne zadanie modyfikujące przesyłkę w bazie danych
        /// </summary>
        /// <param name="delivery"></param>
        /// <returns></returns>
        public static async Task EditDeliveryAsync(Delivery delivery)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                dbContext.Deliveries.Update(delivery);
                await dbContext.SaveChangesAsync();
            }
        }
        /// <summary>
        /// Asynchroniczne statyczne zadanie usuwające przesyłkę z bazy danych
        /// </summary>
        /// <param name="delivery"></param>
        /// <returns></returns>
        public static async Task RemoveDeliveryAsync(Delivery delivery)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                dbContext.Deliveries.Remove(delivery);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
