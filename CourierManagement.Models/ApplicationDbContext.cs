using CourierManagement.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.Models
{
    /// <summary>
    /// Klasa umożliwiająca komunikację z bazą danych
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Łańcuch połączenia z bazą danych (na razie pusty)
        /// </summary>
        private const string CONNECTION_STRING = "";
        public DbSet<Courier> Couriers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CONNECTION_STRING);
        }
    }
}