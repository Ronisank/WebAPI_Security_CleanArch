using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Application.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly RhDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeService(RhDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<dynamic>> GetEmployee()
        {
            try
            {
                if (_context.Employee == null)
                {
                    return new { Message = "Não foi possível retornar a informação." };
                }

                List<Employee> employee = await _context.Employee.ToListAsync();

                var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;


                return employee;
            }
            catch
            {
                return new { Message = "Ocorreu erro durante o processo de geração do token." };
            }
        }

        public async Task<ActionResult<dynamic>> GetEmployee(int id)
        {
            try
            {
                if (_context.Employee == null)
                {
                    return new { Message = "Não foi possível retornar a informação." };
                }
                var employee = await _context.Employee.FindAsync(id);

                if (employee == null)
                {
                    return new { Message = "Não foi possível retornar a informação." };
                }

                return employee;
            }
            catch
            {
                return new { Message = "Ocorreu erro durante o processo de geração do token." };
            }
        }

        public async Task<ActionResult<dynamic>> PutEmployee(int id, Employee employee)
        {
            try
            {
                if (id != employee.Id)
                {
                    return new { Message = "O Id do funcionário informado é diferente do Id da URL." };
                }

                _context.Entry(employee).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(id))
                    {
                        return new { Message = "Não existe funcionário com o Id informado." };
                    }
                    else
                    {
                        throw;
                    }
                }

                return true;
            }
            catch
            {
                return new { Message = "Ocorreu erro durante o processo de geração do token." };
            }
        }


        public async Task<ActionResult<dynamic>> PostEmployee(FuncionarioRequest request)
        {
            try
            {
                if (_context.Employee == null)
                {
                    return new { Message = "Não foi possível retornar a informação." };
                }

                _context.Employee.Add(_mapper.Map<Employee>(request));
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return new { Message = "Ocorreu erro durante o processo de geração do token." };
            }
        }

        public async Task<ActionResult<dynamic>> DeleteEmployee(int id)
        {
            try
            {
                if (_context.Employee == null)
                {
                    return new { Message = "Não foi possível retornar a informação." };
                }
                var employee = await _context.Employee.FindAsync(id);
                if (employee == null)
                {
                    return new { Message = "Não foi possível retornar a informação." };
                }

                _context.Employee.Remove(employee);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return new { Message = "Ocorreu erro durante o processo de geração do token." };
            }
        }

        public async Task<ActionResult<dynamic>> DeleteManager(int id)
        {
            try
            {
                if (_context.Employee == null)
                {
                    return new { Message = "Não foi possível retornar a informação." };
                }
                var employee = await _context.Employee.FindAsync(id);
                if (employee == null)
                {
                    return new { Message = "Não foi possível retornar a informação." };
                }

                _context.Employee.Remove(employee);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return new { Message = "Ocorreu erro durante o processo de geração do token." };
            }
        }

        private bool EmployeeExists(int id)
        {
            return (_context.Employee?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
