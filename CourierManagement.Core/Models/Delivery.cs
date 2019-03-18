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

        [ForeignKey(nameof(Sender))]
        [Required]
        public int SenderId { get; set; }

        [Required]
        public Sender Sender { get; set; }

        [ForeignKey(nameof(Recipient))]
        [Required]
        public int RecipientId { get; set; }

        [Required]
        public Recipient Recipient { get; set; }

        [ForeignKey(nameof(DeliveryCourier))]
        public int DeliveryCourierId { get; set; }

        public Courier DeliveryCourier { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime AcceptanceDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime SentDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ReceivedDate { get; set; }

        [NotMapped]
        public decimal TotalCost { get { return Cost + InsuranceCost; } }

        [DataType(DataType.Currency)]
        [Required]
        public decimal Cost { get; set; }

        [DataType(DataType.Currency)]
        [Required]
        public decimal InsuranceCost { get; set; }

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

        [Required]
        public bool IsInsured { get; set; }

        [Required]
        public bool IsSent { get; set; }

        [Required]
        public bool IsReceived { get; set; }

        public Delivery()
        {
            AcceptanceDate = DateTime.Now;
            IsFragile = false;
            IsInsured = false;
            IsSent = false;
            IsReceived = false;
        }
    }
}