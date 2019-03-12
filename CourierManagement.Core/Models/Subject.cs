using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourierManagement.Core.Models
{
    /// <summary>
    /// Abstrakcyjny model podmiotu
    /// </summary>
    public abstract class Subject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [NotMapped]
        public string FullName { get { return $"{FirstName} {LastName}"; } }

        [NotMapped]
        public string DisplayName
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(FullName) && !string.IsNullOrWhiteSpace(Company))
                    return $"{FullName} ({Company})";
                else if (!string.IsNullOrWhiteSpace(FullName))
                    return FullName;
                else if (!string.IsNullOrWhiteSpace(Company))
                    return Company;
                else
                    return string.Empty;
            }
        }

        public Gender Gender { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
    }
}