using Domain.Entities;

namespace Infrastructure.Seeds
{
    internal static class EmployeeSeed
    {
        public static List<Employee> Seed { get; set; } = new List<Employee>() {
            new Employee
            {
                Id = 1,
                Name= "Funcionário",
                Email = "funcionario@glass.com.br",
                ProfileId = 1,
                Password = "funcionario123",
                Salary = 12546.00M
            },
            new Employee
            {
                Id = 2,
                Name= "Gerente",
                Email = "gerente@glass.com.br",
                ProfileId = 2,
                Password = "gerente123",
                Salary = 23453.89M
            },
            new Employee
            {
                Id = 3,
                Name= "Administrador",
                Email = "administrador@glass.com.br",
                ProfileId = 3,
                Password = "adm123",
                Salary = 36453.34M
            }
        };
    }
}
