var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.AspireLimitsRepro_Console>("console");

builder.Build().Run();
