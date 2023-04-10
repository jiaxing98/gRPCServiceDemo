using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcClientApp
{
    public interface IGrpcService
    {
        string ServiceUrl { get; set; }
    }

    public class GrpcService : IGrpcService
    {
        public string ServiceUrl { get; set; } = "https://localhost:7119";
    }
}
