using CourierManagement.Core.Data;
using CourierManagement.Core.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CourierManagement.Core.Services
{
    public class SenderService : IDataService
    {
        /// <summary>
        /// Kolekcja zawierająca przykładowych nadawców
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Sender> AllSenders()
        {
            var data = new ObservableCollection<Sender>
            {
                new Sender
                {
                    FirstName = "Pan",
                    LastName = "Nadawca",
                    Company = "Firma Krzak",
                    Address = "ul. Nadawcza 1",
                    City = "Gliwice",
                    PostalCode = "44-100",
                    PhoneNumber = "135-246-357",
                    EmailAddress = "pan.nadawca@mail.com"
                },
                new Sender
                {
                    FirstName = "Pani",
                    LastName = "Nadawczyni",
                    Company = "Firma Kogucik",
                    Address = "ul. Nadawcza 2",
                    City = "Gliwice",
                    PostalCode = "44-100",
                    PhoneNumber = "246-357-468",
                    EmailAddress = "pani.nadawczyni@mail.com"
                }
            };
            return data;
        }

        /// <summary>
        /// Asynchroniczne statyczne zadanie pobierające wszystkich nadawców z bazy danych
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<IDataModel>> GetAllFromDatabaseAsync()
        {
            await Task.CompletedTask;
            return AllSenders();
            // TODO: Po utworzeniu bazy danych - odkomentować poniższy kod
            //var data = new ObservableCollection<Sender>();
            //using (var dbContext = new ApplicationDbContext())
            //{
            //    foreach (var item in dbContext.Senders)
            //        data.Add(item);
            //}
            //return data;
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