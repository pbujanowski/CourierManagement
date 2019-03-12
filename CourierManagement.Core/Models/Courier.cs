using System;
using System.ComponentModel.DataAnnotations;

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