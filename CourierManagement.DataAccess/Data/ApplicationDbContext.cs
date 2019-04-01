using CourierManagement.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CourierManagement.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Łańcuch połączenia z bazą danych
        /// </summary>
        private const string ConnectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=couriermanagement;Integrated Security=SSPI;";

        public DbSet<Courier> Couriers { get; set; }
        public DbSet<Sender> Senders { get; set; }
        public DbSet<Recipient> Recipients { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<Return> Returns { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        /// <summary>
        /// Metoda tworząca przykładowe dane, po utworzeniu nowej bazy danych
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var firstSender = new Sender
            {
                Id = 1,
                FirstName = "Pan",
                LastName = "Nadawca",
                Gender = Gender.Male,
                Company = "Firma Krzak",
                Address = "ul. Nadawcza 1",
                City = "Gliwice",
                PostalCode = "44-100",
                PhoneNumber = "135-246-357",
                EmailAddress = "pan.nadawca@mail.com"
            };
            var secondSender = new Sender
            {
                Id = 2,
                FirstName = "Pani",
                LastName = "Nadawczyni",
                Gender = Gender.Female,
                Company = "Firma Kogucik",
                Address = "ul. Nadawcza 2",
                City = "Gliwice",
                PostalCode = "44-100",
                PhoneNumber = "246-357-468",
                EmailAddress = "pani.nadawczyni@mail.com"
            };
            var firstRecipient = new Recipient
            {
                Id = 1,
                FirstName = "Pan",
                LastName = "Odbiorca",
                Gender = Gender.Male,
                Company = "Firma Krzak",
                Address = "ul. Odbiorcza 1",
                City = "Gliwice",
                PostalCode = "44-100",
                PhoneNumber = "135-246-357",
                EmailAddress = "pan.odbiorca@mail.com"
            };
            var secondRecipient = new Recipient
            {
                Id = 2,
                FirstName = "Pani",
                LastName = "Odbiorczyni",
                Gender = Gender.Female,
                Company = "Firma Kogucik",
                Address = "ul. Odbiorcza 2",
                City = "Gliwice",
                PostalCode = "44-100",
                PhoneNumber = "246-357-468",
                EmailAddress = "pani.odbiorczyni@mail.com"
            };
            var firstCourier = new Courier
            {
                Id = 1,
                FirstName = "Jan",
                LastName = "Kowalski",
                Gender = Gender.Male,
                Pesel = "00000000001",
                Birthdate = new DateTime(1990, 01, 01),
                Address = "ul. Jasna 1",
                City = "Gliwice",
                PostalCode = "44-100",
                PhoneNumber = "123-456-789",
                EmailAddress = "jan.kowalski@mail.com"
            };
            var secondCourier = new Courier
            {
                Id = 2,
                FirstName = "Janina",
                LastName = "Kowalska",
                Gender = Gender.Female,
                Pesel = "000000000002",
                Birthdate = new DateTime(1980, 02, 02),
                Address = "ul. Ciemna 2",
                City = "Knurów",
                PostalCode = "44-193",
                PhoneNumber = "789-456-123",
                EmailAddress = "janina.kowalska@mail.com"
            };
            modelBuilder.Entity<Courier>(options => options.HasData(firstCourier, secondCourier));
            modelBuilder.Entity<Sender>(options => options.HasData(firstSender, secondSender));
            modelBuilder.Entity<Recipient>(options => options.HasData(firstRecipient, secondRecipient));
            modelBuilder.Entity<Delivery>(options =>
            {
                options.HasData(
                    new Delivery
                    {
                        Id = 1,
                        SenderId = firstSender.Id,
                        RecipientId = firstRecipient.Id,
                        DeliveryCourierId = firstCourier.Id,
                        SentDate = new DateTime(2019, 3, 8),
                        Cost = 100,
                        PaymentType = DeliveryPaymentType.InAdvance,
                        Length = 200,
                        Width = 250,
                        Height = 300,
                        Weight = 2000,
                        IsFragile = false
                    },
                new Delivery
                {
                    Id = 2,
                    SenderId = secondSender.Id,
                    RecipientId = secondRecipient.Id,
                    DeliveryCourierId = secondCourier.Id,
                    SentDate = new DateTime(2019, 3, 9),
                    Cost = 50,
                    PaymentType = DeliveryPaymentType.OnDelivery,
                    Length = 1000,
                    Width = 200,
                    Height = 200,
                    Weight = 10000,
                    IsFragile = true
                }
                    );
            });
        }
    }
}