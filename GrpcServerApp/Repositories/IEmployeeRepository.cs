using GrpcServerApp.Protos;

namespace GrpcServerApp.Repositories
{
    public interface IEmployeeRepository
    {
        ResponseMessage GetAllEmployee();
    }
}