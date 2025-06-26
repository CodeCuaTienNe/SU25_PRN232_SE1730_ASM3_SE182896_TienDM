using DNATestingSystem.GrpcService.TienDM.Protos;
using DNATestingSystem.Services.TienDM;
using Grpc.Core;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DNATestingSystem.GrpcService.TienDM.Services
{
    public class AppointmentsTienDmGRPCService : AppointmentsTienDmGRPC.AppointmentsTienDmGRPCBase
    {
        private readonly IServiceProviders _serviceProviders;

        //default constructor
        public AppointmentsTienDmGRPCService(IServiceProviders serviceProviders)
        {
            _serviceProviders = serviceProviders;
        }

        public override async Task<AppointmentsTienDmList> GetAllAsync(EmptyRequest request, ServerCallContext context)
        {
            try
            {
                var appointments = await _serviceProviders.AppointmentsTienDmService.GetAllAsync();
                var response = new AppointmentsTienDmList();

                var opt = new JsonSerializerOptions()
                {
                    ReferenceHandler = ReferenceHandler.IgnoreCycles,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                };

                foreach (var appointment in appointments)
                {
                    // Serialize to JSON and deserialize to gRPC model
                    var jsonString = JsonSerializer.Serialize(appointment, opt);
                    var grpcModel = JsonSerializer.Deserialize<AppointmentsTienDm>(jsonString, opt);

                    if (grpcModel != null)
                    {
                        response.Appointments.Add(grpcModel);
                    }
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, $"Error in GetAllAsync: {ex.Message}"));
            }
        }

        public override async Task<AppointmentsTienDm> GetByIdAsync(GetByIdRequest request, ServerCallContext context)
        {
            try
            {
                var appointment = await _serviceProviders.AppointmentsTienDmService.GetByIdAsync(request.AppointmentsTienDmid);

                if (appointment == null)
                {
                    throw new RpcException(new Status(StatusCode.NotFound, "Appointment not found"));
                }

                var opt = new JsonSerializerOptions()
                {
                    ReferenceHandler = ReferenceHandler.IgnoreCycles,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                };

                // Serialize to JSON and deserialize to gRPC model
                var jsonString = JsonSerializer.Serialize(appointment, opt);
                var grpcModel = JsonSerializer.Deserialize<AppointmentsTienDm>(jsonString, opt);

                return grpcModel ?? new AppointmentsTienDm();
            }
            catch (RpcException)
            {
                throw; // Re-throw RPC exceptions
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, $"Error in GetByIdAsync: {ex.Message}"));
            }
        }

        public override async Task<MutationResult> CreateAsync(AppointmentsTienDm request, ServerCallContext context)
        {
            try
            {
                var opt = new JsonSerializerOptions()
                {
                    ReferenceHandler = ReferenceHandler.IgnoreCycles,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                };

                // Convert gRPC model to domain model using JSON serialization
                var protoJsonString = JsonSerializer.Serialize(request, opt);
                var domainModel = JsonSerializer.Deserialize<DNATestingSystem.Repository.TienDM.Models.AppointmentsTienDm>(protoJsonString, opt);

                if (domainModel == null)
                {
                    throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid appointment data"));
                }

                var result = await _serviceProviders.AppointmentsTienDmService.CreateAsync(domainModel);

                return new MutationResult() { Result = result };
            }
            catch (RpcException)
            {
                throw; // Re-throw RPC exceptions
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, $"Error in CreateAsync: {ex.Message}"));
            }
        }

        public override async Task<MutationResult> UpdateAsync(AppointmentsTienDm request, ServerCallContext context)
        {
            try
            {
                var opt = new JsonSerializerOptions()
                {
                    ReferenceHandler = ReferenceHandler.IgnoreCycles,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                };

                // Convert gRPC model to domain model using JSON serialization
                var protoJsonString = JsonSerializer.Serialize(request, opt);
                var domainModel = JsonSerializer.Deserialize<DNATestingSystem.Repository.TienDM.Models.AppointmentsTienDm>(protoJsonString, opt);

                if (domainModel == null)
                {
                    throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid appointment data"));
                }

                var result = await _serviceProviders.AppointmentsTienDmService.UpdateAsync(domainModel);

                return new MutationResult() { Result = result };
            }
            catch (RpcException)
            {
                throw; // Re-throw RPC exceptions
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, $"Error in UpdateAsync: {ex.Message}"));
            }
        }

        public override async Task<MutationResult> DeleteAsync(DeleteRequest request, ServerCallContext context)
        {
            try
            {
                var result = await _serviceProviders.AppointmentsTienDmService.DeleteAsync(request.Id);

                return new MutationResult() { Result = result ? 1 : 0 };
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, $"Error in DeleteAsync: {ex.Message}"));
            }
        }
    }
}
