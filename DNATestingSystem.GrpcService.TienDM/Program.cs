using DNATestingSystem.GrpcService.TienDM.Services;
using DNATestingSystem.Services.TienDM;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();

// Add Scope Service - Register the service providers
builder.Services.AddScoped<IServiceProviders, ServiceProviders>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGrpcService<AppointmentsTienDmGRPCService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
