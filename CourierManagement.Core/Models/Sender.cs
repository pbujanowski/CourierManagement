using System.ComponentModel.DataAnnotations;

namespace CourierManagement.Core.Models
{
    /// <summary>
    /// Model nadawcy przesyłki
    /// </summary>
    public class Sender : Subject, IDataModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
    }
}