using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.Core.Models
{
    /// <summary>
    /// Model kuriera
    /// </summary>
    public class Courier : Subject, IModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Pesel { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime Birthdate { get; set; }
    }
}
