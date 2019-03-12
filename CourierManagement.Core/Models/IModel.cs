using System.ComponentModel.DataAnnotations;

namespace CourierManagement.Core.Models
{
    /// <summary>
    /// Interfejs dla modeli
    /// </summary>
    internal interface IModel
    {
        [Key]
        [Required]
        int Id { get; set; }
    }
}