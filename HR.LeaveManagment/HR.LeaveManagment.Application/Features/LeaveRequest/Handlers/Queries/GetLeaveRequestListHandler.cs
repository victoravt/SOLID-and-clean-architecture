using AutoMapper;
using HR.LeaveManagment.Application.DTOs.LeaveRequestDto;
using HR.LeaveManagment.Application.Features.LeaveRequest.Requestes.Queries;
using HR.LeaveManagment.Application.Persistence.Contracts;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagment.Application.Features.LeaveRequest.Handlers.Queries
{
    public class GetLeaveRequestListHandler : IRequestHandler<GetLeaveRequestListRequest, List<LeaveRequestListDto>>
    {
        private ILeaveRequestRepository _leaveRequestRepository;
        private IMapper _mapper;

        public GetLeaveRequestListHandler(ILeaveRequestRepository leaveRequestRepository,
            IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<List<LeaveRequestListDto>> Handle(GetLeaveRequestListRequest request, CancellationToken cancellationToken)
        {
            var list = await _leaveRequestRepository.GetAll();
            return _mapper.Map<List<LeaveRequestListDto>>(list);
        }
    }
}
