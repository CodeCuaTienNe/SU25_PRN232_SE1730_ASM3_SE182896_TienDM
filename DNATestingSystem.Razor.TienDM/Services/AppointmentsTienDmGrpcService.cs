using DNATestingSystem.GrpcService.TienDM.Protos;
using Grpc.Core;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DNATestingSystem.Razor.TienDM.Services
{
    public class AppointmentsTienDmGrpcService
    {
        private readonly AppointmentsTienDmGRPC.AppointmentsTienDmGRPCClient _client;

        public AppointmentsTienDmGrpcService(AppointmentsTienDmGRPC.AppointmentsTienDmGRPCClient client)
        {
            _client = client;
        }

        public List<AppointmentsTienDm> GetAll()
        {
            try
            {
                var response = _client.GetAllAsync(new EmptyRequest());
                return response.Appointments.ToList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to get appointments", ex);
            }
        }

        public AppointmentsTienDm? GetById(int id)
        {
            try
            {
                var request = new GetByIdRequest { AppointmentsTienDmid = id };
                var response = _client.GetByIdAsync(request);
                return response;
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.NotFound)
            {
                return null;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Failed to get appointment with id {id}", ex);
            }
        }

        public int Create(AppointmentsTienDm appointment)
        {
            try
            {
                var response = _client.CreateAsync(appointment);
                return response.Result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to create appointment", ex);
            }
        }

        public int Update(AppointmentsTienDm appointment)
        {
            try
            {
                var response = _client.UpdateAsync(appointment);
                return response.Result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Failed to update appointment with id {appointment.AppointmentsTienDmid}", ex);
            }
        }

        public int Delete(int id)
        {
            try
            {
                var request = new DeleteRequest { Id = id };
                var response = _client.DeleteAsync(request);
                return response.Result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Failed to delete appointment with id {id}", ex);
            }
        }

        // Async version for Details page and future compatibility
        public async Task<AppointmentsTienDm?> GetByIdAsync(int id)
        {
            try
            {
                var request = new GetByIdRequest { AppointmentsTienDmid = id };
                var response = _client.GetByIdAsync(request);
                return response;
            }
            catch (Grpc.Core.RpcException ex) when (ex.StatusCode == Grpc.Core.StatusCode.NotFound)
            {
                return null;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Failed to get appointment with id {id}", ex);
            }
        }
    }
}
