var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var postgres = builder.AddPostgres("postgres");

var userDb = postgres.AddDatabase("UserDb");
var userRegisterDb = postgres.AddDatabase("UserRegisterDb");
var inventoryDb = postgres.AddDatabase("Inventory");


var apiService = builder.AddProject<Projects.PokemonServer_ApiService>("apiservice");

builder.AddProject<Projects.PokemonServer_Web>("webfrontend")
	.WithExternalHttpEndpoints()
	.WithReference(cache)
	.WithReference(apiService);

builder.AddProject<Projects.Battle_API>("battle-api")
	.WithReference(userDb)
	.WithReference(userRegisterDb);

builder.AddProject<Projects.Register_API>("register-api")
	.WithReference(userRegisterDb);

builder.Build().Run();
