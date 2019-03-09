using CourierManagement.Core.Data;
using CourierManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.Core.Services
{
    public class RecipientService
    {
        /// <summary>
        /// Asynchroniczne statyczne zadanie pobierające wszystkich odbiorców z bazy danych
        /// </summary>
        /// <returns></returns>
        public static async Task<IEnumerable<Recipient>> GetRecipientsAsync()
        {
            await Task.CompletedTask;
            var data = new ObservableCollection<Recipient>();
            using (var dbContext = new ApplicationDbContext())
            {
                foreach (var item in dbContext.Recipients)
                    data.Add(item);
            }
            return data;
        }
        /// <summary>
        /// Asynchroniczne statyczne zadanie dodające nowego odbiorcę do bazy danych
        /// </summary>
        /// <param name="recipient"></param>
        /// <returns></returns>
        public static async Task AddRecipientAsync(Recipient recipient)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                await dbContext.Recipients.AddAsync(recipient);
                await dbContext.SaveChangesAsync();
            }
        }
        /// <summary>
        /// Asynchroniczne statyczne zadanie modyfikujące odbiorcę w bazie danych
        /// </summary>
        /// <param name="recipient"></param>
        /// <returns></returns>
        public static async Task EditRecipientAsync(Recipient recipient)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                dbContext.Recipients.Update(recipient);
                await dbContext.SaveChangesAsync();
            }
        }
        /// <summary>
        /// Asynchroniczne statyczne zadanie usuwające odbiorcę z bazy danych
        /// </summary>
        /// <param name="recipient"></param>
        /// <returns></returns>
        public static async Task RemoveRecipientAsync(Recipient recipient)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                dbContext.Recipients.Remove(recipient);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
