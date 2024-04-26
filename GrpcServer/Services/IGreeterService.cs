using Grpc.Core;

namespace GrpcServer.Services
{
    public interface IGreeterService
    {
        Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context);
    }
}