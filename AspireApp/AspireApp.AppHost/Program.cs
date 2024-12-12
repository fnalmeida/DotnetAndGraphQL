var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var apiService = builder.AddProject<Projects.AspireApp_ApiService>("apiservice");
var apiGraphql = builder.AddProject<Projects.AspireApp_GraphqlApi>("aspireapp-graphqlapi");


builder.AddProject<Projects.AspireApp_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WithReference(apiService)
    .WithReference(apiGraphql);

//builder.AddProject<Projects.WebApplication1>("webapplication1");


//builder.AddProject<Projects.WebApplication1>("webapplication1");

builder.Build().Run();
