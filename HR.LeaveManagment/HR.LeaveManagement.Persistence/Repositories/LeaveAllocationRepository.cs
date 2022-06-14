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
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private LeaveManagementDbContext _dbContext;

        public LeaveAllocationRepository(LeaveManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
        {
            return await _dbContext.LeaveAllocations
                .Include(x => x.LeaveType)
                .FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails()
        {
            return await _dbContext.LeaveAllocations
                .Include(x => x.LeaveType)
                .ToListAsync();
        }
    }
}
