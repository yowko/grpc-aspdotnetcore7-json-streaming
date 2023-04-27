using Grpc.Core;

namespace NET7GrpcService.Services;

public class ExampleService:NET7GrpcService.ExampleService.ExampleServiceBase
{
    public override async Task StreamingFromServer(ExampleRequest request, IServerStreamWriter<ExampleResponse> responseStream, ServerCallContext context)
    {
        for (var i = 1; i <= 3; i++)
        {
            await responseStream.WriteAsync(new ExampleResponse { Text = $"Message {i}" });
            await Task.Delay(TimeSpan.FromSeconds(1));
        }
    }
}