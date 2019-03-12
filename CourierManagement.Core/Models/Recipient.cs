using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourierManagement.Core.Models
{
    /// <summary>
    /// Model odbiorcy przesyłki
    /// </summary>
    public class Recipient : Subject, IModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public IEnumerable<Delivery> ReceivedDeliveries { get; set; }
    }
}