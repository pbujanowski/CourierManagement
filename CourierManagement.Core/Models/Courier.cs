using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.Core.Models
{
    /// <summary>
    /// Klasa modelu kuriera
    /// </summary>
    public class Courier : Person, IDomainModel
    {
        public int Id { get; set; }
        public string Pesel { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
