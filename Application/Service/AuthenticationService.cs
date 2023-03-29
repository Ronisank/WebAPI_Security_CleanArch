using Application.DTOs;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Application.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly RhDbContext _context;
        private readonly ITokenService _tokenService;
        public AuthenticationService(RhDbContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public async Task<ActionResult<dynamic>> AuthenticateUser(EmployeeDto dto)
        {
            try
            {
                var user = await _context.Employee.Include(x => x.Profile)
                        .FirstOrDefaultAsync(x => x.Email == dto.Email && x.Password == dto.Password).ConfigureAwait(false);

                if (user == null)
                {
                    return new { Message = "Funcionário e/ou senha inválidos." };
                }

                var token = _tokenService.GenerateToken(user);
                var result = new
                {
                    token,
                    User = new
                    {
                        user.Id,
                        user.Name,
                        user.Email,
                        user.ProfileId
                    }
                };
                user.Password = "";
                return new { result };
            }
            catch
            {
                return new { Message = "Ocorreu erro durante o processo de geração do token." };
            }
        }
    }
}
