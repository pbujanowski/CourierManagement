using CourierManagement.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CourierManagement.Core.Data
{
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Łańcuch połączenia z bazą danych (na razie pusty)
        /// </summary>
        private const string ConnectionString = "";

        public DbSet<Courier> Couriers { get; set; }
        public DbSet<Sender> Senders { get; set; }
        public DbSet<Recipient> Recipients { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}