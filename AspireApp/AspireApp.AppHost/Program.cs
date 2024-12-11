var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var apiService = builder.AddProject<Projects.AspireApp_ApiService>("apiservice");

builder.AddProject<Projects.AspireApp_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WithReference(apiService);

//builder.AddProject<Projects.WebApplication1>("webapplication1");

builder.AddProject<Projects.AspireApp_GraphqlApi>("aspireapp-graphqlapi");

//builder.AddProject<Projects.WebApplication1>("webapplication1");

builder.Build().Run();
