using Application.DTOs;
using Application.Service;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers
{
    [Route("api/employee")]
    [ApiController]
    //[Authorize]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Authorize(Roles = ("Employee, Manager, Administrator"))]
        public async Task<ActionResult<dynamic>> GetEmployee()
        {
            return await _employeeService.GetEmployee();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = ("Employee, Manager, Administrator"))]
        public async Task<ActionResult<dynamic>> GetEmployee(int id)
        {
            return await _employeeService.GetEmployee(id);
        }

        [HttpPut("update-salary/{id}")]
        [Authorize(Roles = ("Manager"))]
        public async Task<ActionResult<dynamic>> PutEmployee(int id, Employee employee)
        {
            return await _employeeService.PutEmployee(id, employee);
        }

        [HttpPost("create-employee")]
        [Authorize(Roles = ("Administrator"))]
        public async Task<ActionResult<dynamic>> PostEmployee(FuncionarioRequest request)
        {
            return await _employeeService.PostEmployee(request);
        }

        [HttpDelete("delete-employee/{id}")]
        [Authorize(Roles = ("Manager, Administrator"))]
        public async Task<ActionResult<dynamic>> DeleteEmployee(int id)
        {
            return await _employeeService.DeleteEmployee(id);
        }

        [HttpDelete("delete-manager/{id}")]
        [Authorize(Roles = ("Administrator"))]
        public async Task<ActionResult<dynamic>> DeleteManager(int id)
        {
            return await _employeeService.DeleteManager(id);
        }
    }
}