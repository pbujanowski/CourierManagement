using CourierManagement.Core.Data;
using CourierManagement.Core.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CourierManagement.Core.Services
{
    public class RecipientService : IDataService
    {
        /// <summary>
        /// Kolekcja zawierająca przykładowych odbiorców
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Recipient> AllRecipients()
        {
            var data = new ObservableCollection<Recipient>
            {
                new Recipient
                {
                    FirstName = "Pan",
                    LastName = "Odbiorca",
                    Company = "Firma Krzak",
                    Address = "ul. Odbiorcza 1",
                    City = "Gliwice",
                    PostalCode = "44-100",
                    PhoneNumber = "135-246-357",
                    EmailAddress = "pan.odbiorca@mail.com"
                },
                new Recipient
                {
                    FirstName = "Pani",
                    LastName = "Odbiorczyni",
                    Company = "Firma Kogucik",
                    Address = "ul. Odbiorcza 2",
                    City = "Gliwice",
                    PostalCode = "44-100",
                    PhoneNumber = "246-357-468",
                    EmailAddress = "pani.odbiorczyni@mail.com"
                }
            };
            return data;
        }

        /// <summary>
        /// Asynchroniczne statyczne zadanie pobierające wszystkich odbiorców z bazy danych
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<IDataModel>> GetAllFromDatabaseAsync()
        {
            await Task.CompletedTask;
            return AllRecipients();
            //var data = new ObservableCollection<Recipient>();
            //using (var dbContext = new ApplicationDbContext())
            //{
            //    foreach (var item in dbContext.Recipients)
            //        data.Add(item);
            //}
            //return data;
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