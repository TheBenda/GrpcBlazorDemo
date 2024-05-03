var builder = DistributedApplication.CreateBuilder(args);

var pizzaOrderDb = builder.AddPostgres("pizzaorder", password: builder.CreateStablePassword("pizzaorder-password"))
    .WithDataVolume()
    .AddDatabase("pizzaorderdb");

var grpcbackend = builder.AddProject<Projects.GrpcBackend>("grpcbackend");

builder.AddProject<Projects.BlazorFrontend>("blazorfrontend").WithReference(grpcbackend);

builder.AddProject<Projects.Infrastructure>("infrastructure").WithReference(pizzaOrderDb);

builder.Build().Run();