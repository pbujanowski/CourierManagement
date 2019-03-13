using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourierManagement.Core.Models
{
    /// <summary>
    /// Model przesyłki
    /// </summary>
    public class Delivery : IDataModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [NotMapped]
        public string DisplayName { get { return $"Przesyłka nr {Id}"; } }

        [Required]
        public Sender Sender { get; set; }

        [Required]
        public Recipient Recipient { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime SentDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReceivedDate { get; set; }

        [DataType(DataType.Currency)]
        [Required]
        public decimal Cost { get; set; }

        [Required]
        public DeliveryPaymentType PaymentType { get; set; }

        [Required]
        public int Length { get; set; }

        [Required]
        public int Width { get; set; }

        [Required]
        public int Height { get; set; }

        [Required]
        public int Weight { get; set; }

        [Required]
        public bool IsFragile { get; set; }
    }
}