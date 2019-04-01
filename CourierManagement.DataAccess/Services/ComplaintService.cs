using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourierManagement.Core.Models;
using CourierManagement.DataAccess.Data;

namespace CourierManagement.DataAccess.Services
{
    public class ComplaintService : IDataService
    {
        public async Task AddToDatabaseAsync(IDataModel model)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                await dbContext.Complaints.AddAsync((Complaint)model).ConfigureAwait(false);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public async Task EditInDatabaseAsync(IDataModel model)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                dbContext.Complaints.Update((Complaint)model);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public async Task<IEnumerable<IDataModel>> GetAllFromDatabaseAsync()
        {
            await Task.CompletedTask;
            using (var dbContext = new ApplicationDbContext())
            {
                return (from complaints in dbContext.Complaints
                        join deliveries in dbContext.Deliveries on complaints.ComplainedDeliveryId equals deliveries.Id
                        select new Complaint
                        {
                            Id = complaints.Id,
                            ComplainedDeliveryId = complaints.ComplainedDeliveryId,
                            ComplainedDelivery = complaints.ComplainedDelivery,
                            Description = complaints.Description,
                            SubmissionDate = complaints.SubmissionDate,
                            ComplaintDate = complaints.ComplaintDate,
                            Status = complaints.Status
                        }).ToList();
            }
        }

        public async Task RemoveFromDatabaseAsync(IDataModel model)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                dbContext.Complaints.Remove((Complaint)model);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
        }
    }
}
