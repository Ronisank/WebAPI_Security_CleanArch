using Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Application.Service
{
    public interface IAuthenticationService
    {
        Task<ActionResult<dynamic>> AuthenticateUser(EmployeeDto dto);
    }

}
