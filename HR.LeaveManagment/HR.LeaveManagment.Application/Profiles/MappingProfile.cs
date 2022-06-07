using AutoMapper;
using HR.LeaveManagement.Domain;
using HR.LeaveManagment.Application.DTOs;
using HR.LeaveManagment.Application.DTOs.LeaveRequestDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagment.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestListDto>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
        }
    }
}
