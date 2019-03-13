using CourierManagement.Core.Data;
using CourierManagement.Core.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CourierManagement.Core.Services
{
    /// <summary>
    /// Usługa dla modelu kuriera
    /// </summary>
    public class CourierService : IDataService
    {
        /// <summary>
        /// Kolekcja zawierająca przykładowych kurierów
        /// </summary>
        /// <returns></returns>
        private IEnumerable<IDataModel> AllCouriers()
        {
            var data = new ObservableCollection<Courier>
            {
                new Courier
                {
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    Address = "ul. Jasna 1",
                    City = "Gliwice",
                    PostalCode = "44-100",
                    PhoneNumber = "123-456-789",
                    EmailAddress = "jan.kowalski@mail.com"
                },
                new Courier
                {
                    FirstName = "Janina",
                    LastName = "Kowalska",
                    Address = "ul. Ciemna 2",
                    City = "Knurów",
                    PostalCode = "44-193",
                    PhoneNumber = "789-456-123",
                    EmailAddress = "janina.kowalska@mail.com"
                }
            };
            return data;
        }

        /// <summary>
        /// Asynchroniczne zadanie zwracające kolekcję z wszystkimi kurierami z bazy danych
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<IDataModel>> GetAllFromDatabaseAsync()
        {
            await Task.CompletedTask;

            return AllCouriers();
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