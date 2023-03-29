using Application.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Application.Service
{
    public interface IEmployeeService
    {
        Task<ActionResult<dynamic>> GetEmployee();
        Task<ActionResult<dynamic>> GetEmployee(int id);
        Task<ActionResult<dynamic>> PutEmployee(int id, Employee employee);
        Task<ActionResult<dynamic>> PostEmployee(FuncionarioRequest request);
        Task<ActionResult<dynamic>> DeleteEmployee(int id);
        Task<ActionResult<dynamic>> DeleteManager(int id);
    }
}
