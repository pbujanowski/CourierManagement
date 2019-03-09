using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.Core.Models
{
    /// <summary>
    /// Interfejs dla modeli
    /// </summary>
    interface IModel
    {
        [Key]
        [Required]
        int Id { get; set; }
    }
}
