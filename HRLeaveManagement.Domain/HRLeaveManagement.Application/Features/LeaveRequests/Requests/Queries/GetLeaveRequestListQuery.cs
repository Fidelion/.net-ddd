using System;
using HRLeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveRequests.Requests.Queries
{
    public class GetLeaveRequestListQuery : IRequest<List<LeaveRequestListDto>>
    {
    }
}


