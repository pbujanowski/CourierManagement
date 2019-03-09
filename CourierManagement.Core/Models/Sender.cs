using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.Core.Models
{
    /// <summary>
    /// Klasa modelu nadawcy
    /// </summary>
    public class Sender : Person, IDomainModel
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }

    }
}
