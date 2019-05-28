using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourierManagement.Core.Models
{
    public class Complaint : IDataModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [ForeignKey(nameof(ComplainedDelivery))]
        [Required]
        public int ComplainedDeliveryId { get; set; }

        [Required]
        public Delivery ComplainedDelivery { get; set; }

        [Required]
        [StringLength(250, ErrorMessage = "Maksymalna długość opisu reklamacji wynosik 250 znaków!")]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime SubmissionDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ComplaintDate { get; set; }

        [Required]
        public ComplaintStatusType Status { get; set; }

        public Complaint()
        {
            SubmissionDate = DateTime.Now;
            Status = ComplaintStatusType.InProgress;
        }
    }
}