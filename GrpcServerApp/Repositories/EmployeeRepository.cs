using GrpcServerApp.Protos;

namespace GrpcServerApp.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public ResponseMessage GetAllEmployee()
        {
            var rand = new Random();
            var employeesData = Enumerable.Range(1, 100)
                .Select(index => new EmployeeModel
                {
                    Email = $"Test Email: {rand.Next(-20, 55)}@test.com",
                    Name = $"Test Name: {rand.Next(-20, 55)}",
                    Skill = $"Test Skill: {rand.Next(-20, 55)}",
                })
                .ToArray();

            return new ResponseMessage
            {
                Employees = { employeesData },
                Success = true,
                Message = "Success",
            };
        }
    }
}
