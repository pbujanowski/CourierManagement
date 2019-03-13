using System.ComponentModel.DataAnnotations;

namespace CourierManagement.Core.Models
{
    /// <summary>
    /// Interfejs dla modeli
    /// </summary>
    public interface IDataModel
    {
        [Key]
        [Required]
        int Id { get; set; }
    }
}