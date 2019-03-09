using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.Core.Models
{
    public class Recipient : Person, IDomainModel
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
    }
}
