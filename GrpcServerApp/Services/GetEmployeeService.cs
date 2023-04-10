using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcServerApp.Protos;
using GrpcServerApp.Repositories;

namespace GrpcServerApp.Services
{
    public class GetEmployeeService :  EmployeeService.EmployeeServiceBase
    {
        private readonly ILogger<GetEmployeeService> _logger;
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeService(ILogger<GetEmployeeService> logger, IEmployeeRepository employeeRepository)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
        }

        public override Task<ResponseMessage>? GetAllEmployee(Empty request, ServerCallContext context)
        {
            try
            {
                var result = _employeeRepository.GetAllEmployee();
                return Task.FromResult(result);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

        }
    }
}
