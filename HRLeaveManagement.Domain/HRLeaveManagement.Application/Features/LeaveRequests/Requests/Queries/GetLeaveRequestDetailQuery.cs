using System;
using HRLeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveRequests.Requests.Queries
{
    public class GetLeaveRequestDetailQuery : IRequest<LeaveRequestDto>
    {
        public int Id { get; set; }
    }
}

