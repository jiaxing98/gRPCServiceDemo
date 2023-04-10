using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GrpcServerApp.Protos.EmployeeService;

namespace GrpcClientApp
{
    public class WorkerService : BackgroundService
    {
        private readonly ILogger<WorkerService> _logger;
        private readonly IGrpcService _grpcService;
        private EmployeeServiceClient? _client;

        public WorkerService(ILogger<WorkerService> logger, IGrpcService grpcService)
        {
            _logger = logger;
            _grpcService = grpcService;
        }

        protected EmployeeServiceClient Client
        {
            get
            {
                if (_client == null)
                {
                    var channel = GrpcChannel.ForAddress(_grpcService.ServiceUrl);
                    _client = new EmployeeServiceClient(channel);
                }
                return _client;
            }
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var result = Client.GetAllEmployee(new Empty(), cancellationToken: stoppingToken);
            Console.WriteLine($"Result From Worker Service: {result}");

            return Task.FromResult(result);
        }
    }
}
