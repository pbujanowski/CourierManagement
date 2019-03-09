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
        /// Metoda pobierająca wszystkich kurierów z bazy danych i zwracająca ich w postaci kolekcji
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<Courier> AllCouriers()
        {
            var data = new ObservableCollection<Courier>
            {
                new Courier
                {
                    FirstName = "Patryk",
                    LastName = "Bujanowski"
                },
                new Courier
                {
                    FirstName = "Jan",
                    LastName = "Kowalski"
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
    }
}
