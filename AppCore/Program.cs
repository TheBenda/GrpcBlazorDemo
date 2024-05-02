var builder = DistributedApplication.CreateBuilder(args);

var grpcbackend = builder.AddProject<Projects.GrpcBackend>("grcpbackend");

builder.AddProject<Projects.BlazorFrontend>("blazorfrontend").WithReference(grpcbackend);

builder.Build().Run();