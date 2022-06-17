using HR.LeaveManagement.Domain;
using HR.LeaveManagment.Application.Contracts.Persistence;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.UnitTests.Mocks
{
    public static class MockLeaveTypeRepository
    {
        public static Mock<ILeaveTypeRepository> GetLeaveTypeRepostiry()
        {
            var leaveTypes = new List<LeaveType>
            {
                new()
                {
                    Id = 1,
                    DefaultDays = 10,
                    Name = "Test vac"
                },
                new()
                {
                    Id = 2,
                    DefaultDays = 25,
                    Name = "Test Sick"
                }
            };

            var mockRepo = new Mock<ILeaveTypeRepository>();

            mockRepo.Setup(r=>r.GetAll()).ReturnsAsync(leaveTypes);

            mockRepo.Setup(r => r.Add(It.IsAny<LeaveType>())).ReturnsAsync((LeaveType l) =>
                {
                    leaveTypes.Add(l);
                    return l;
                }
            );

            return mockRepo;
        }
    }
}
