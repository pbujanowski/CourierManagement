using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.Core.Models
{
    /// <summary>
    /// Interfejs dla modeli
    /// </summary>
    interface IDomainModel
    {
        int Id { get; set; }
    }
}
