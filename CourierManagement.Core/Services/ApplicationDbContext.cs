using CourierManagement.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourierManagement.Core.Services
{
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Łańcuch połączenia z bazą danych (na razie pusty)
        /// </summary>
        private const string CONNECTION_STRING = "";
        public DbSet<Courier> Couriers { get; set; }
        public DbSet<Sender> Senders { get; set; }
        public DbSet<Recipient> Recipients { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CONNECTION_STRING);
        }
    }
}
