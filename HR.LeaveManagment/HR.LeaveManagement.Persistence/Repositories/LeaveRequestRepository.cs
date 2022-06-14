using HR.LeaveManagement.Domain;
using HR.LeaveManagment.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private LeaveManagementDbContext _dbContext;
        public LeaveRequestRepository(LeaveManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? approvalStatus)
        {
            leaveRequest.Approved = approvalStatus;
            _dbContext.Entry(leaveRequest).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }        

        public Task<List<LeaveRequest>> GetLeaveRequestWithDetails()
        {
            var res = _dbContext.LeaveRequests
                .Include(q => q.LeaveType)
                .ToListAsync();
            return res;

        }

        public Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {
            return _dbContext.LeaveRequests
                .Include(i=>i.LeaveType)
                .FirstOrDefaultAsync(x=>x.Id == id);
        }
    }
}
