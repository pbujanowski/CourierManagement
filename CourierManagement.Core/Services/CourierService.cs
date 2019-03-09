using CourierManagement.Core.Data;
using CourierManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.Core.Services
{
    /// <summary>
    /// Usługa dla modelu kuriera
    /// </summary>
    public static class CourierService
    {
        /// <summary>
        /// Kolekcja zawierająca przykładowych kurierów
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<Courier> AllCouriers()
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
        public static async Task<IEnumerable<Courier>> GetCouriersAsync()
        {
            await Task.CompletedTask;

            return AllCouriers();
        }
        /// <summary>
        /// Asynchroniczne statyczne zadanie dodające nowego kuriera do bazy danych
        /// </summary>
        /// <param name="courier"></param>
        public static async Task AddCourierAsync(Courier courier)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                await dbContext.Couriers.AddAsync(courier);
                await dbContext.SaveChangesAsync();
            }
        }
        /// <summary>
        /// Asynchroniczne statyczne zadanie modyfikujące istniejącego kuriera w bazie danych
        /// </summary>
        /// <param name="courier"></param>
        public static async Task EditCourierAsync(Courier courier)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                dbContext.Couriers.Update(courier);
                await dbContext.SaveChangesAsync();
            }
        }
        /// <summary>
        /// Asynchroniczne statyczne zadanie usuwające istniejącego kuriera z bazy danych
        /// </summary>
        /// <param name="courier"></param>
        public static async Task RemoveCourierAsync(Courier courier)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                dbContext.Couriers.Remove(courier);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
