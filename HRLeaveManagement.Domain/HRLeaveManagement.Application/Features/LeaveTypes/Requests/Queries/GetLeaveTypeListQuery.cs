using System;
using HRLeaveManagement.Application.DTOs.LeaveType;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetLeaveTypeListQuery : IRequest<List<LeaveTypeDto>>
    {
    }
}


