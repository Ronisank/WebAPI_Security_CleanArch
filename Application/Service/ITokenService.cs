using Domain.Entities;

namespace Application.Service
{
    public interface ITokenService
    {
        string GenerateToken(Employee employee);
    }
}
