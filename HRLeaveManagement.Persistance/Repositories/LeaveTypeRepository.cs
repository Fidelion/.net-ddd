using System;
using HRLeaveManagement.Application.Contracts.Persistance;
using HRLeaveManagement.Domain;

namespace HRLeaveManagement.Persistance.Repositories
{
    public class LeaveTypeRepository: GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        private readonly LeaveManagementDbContext _dbContext;

        public LeaveTypeRepository(LeaveManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
