using CourierManagement.Core.Data;
using CourierManagement.Core.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.Core.Services
{
    public static class SenderService
    {
        /// <summary>
        /// Kolekcja zawierająca przykładowych nadawców
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<Sender> AllSenders()
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
        public static async Task<IEnumerable<Sender>> GetSendersAsync()
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
        public static async Task AddSenderAsync(Sender sender)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                await dbContext.Senders.AddAsync(sender);
                await dbContext.SaveChangesAsync();
            }
        }
        /// <summary>
        /// Asynchroniczne statyczne zadanie modyfikujące nadawcę w bazie danych
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static async Task EditSenderAsync(Sender sender)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                dbContext.Senders.Update(sender);
                await dbContext.SaveChangesAsync();
            }
        }
        /// <summary>
        /// Asynchroniczne statyczne zadanie usuwające nadawcę z bazy danych
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static async Task RemoveSenderAsync(Sender sender)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                dbContext.Senders.Remove(sender);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
