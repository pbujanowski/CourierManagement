using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourierManagement.Core.Models
{
    public class Return : IDataModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [ForeignKey(nameof(Delivery))]
        [Required]
        public int DeliveryId { get; set; }

        [Required]
        public Delivery Delivery { get; set; }

        [DataType(DataType.Currency)]
        [Required]
        public decimal Cost { get; set; }

        [DataType(DataType.DateTime)]
        [Required]
        public DateTime AcceptanceDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ReturnDate { get; set; }

        [Required]
        public bool IsReturned { get; set; }

        public Return()
        {
            AcceptanceDate = DateTime.Now;
            IsReturned = false;
        }
    }
}