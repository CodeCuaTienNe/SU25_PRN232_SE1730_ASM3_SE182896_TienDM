using DNATestingSystem.Repository.TienDM.Models;
using DNATestingSystem.Repository.TienDM.ModelExtensions;

namespace DNATestingSystem.Repository.TienDM.ModelExtensions
{
    /// <summary>
    /// Mapper for converting between AppointmentsTienDm entity and DTOs
    /// </summary>
    public static class AppointmentsTienDmMapper
    {
        /// <summary>
        /// Convert CreateDto to Entity
        /// </summary>
        public static AppointmentsTienDm ToEntity(this CreateAppointmentsTienDmDto dto)
        {
            return new AppointmentsTienDm
            {
                UserAccountId = dto.UserAccountId,
                ServicesNhanVtid = dto.ServicesNhanVtid,
                AppointmentStatusesTienDmid = dto.AppointmentStatusesTienDmid,
                AppointmentDate = dto.AppointmentDate,
                AppointmentTime = dto.AppointmentTime,
                SamplingMethod = dto.SamplingMethod,
                Address = dto.Address,
                ContactPhone = dto.ContactPhone,
                Notes = dto.Notes,
                TotalAmount = dto.TotalAmount,
                IsPaid = dto.IsPaid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
        }

        /// <summary>
        /// Convert UpdateDto to Entity
        /// </summary>
        public static AppointmentsTienDm ToEntity(this UpdateAppointmentsTienDmDto dto)
        {
            return new AppointmentsTienDm
            {
                AppointmentsTienDmid = dto.AppointmentsTienDmid,
                UserAccountId = dto.UserAccountId,
                ServicesNhanVtid = dto.ServicesNhanVtid,
                AppointmentStatusesTienDmid = dto.AppointmentStatusesTienDmid,
                AppointmentDate = dto.AppointmentDate,
                AppointmentTime = dto.AppointmentTime,
                SamplingMethod = dto.SamplingMethod,
                Address = dto.Address,
                ContactPhone = dto.ContactPhone,
                Notes = dto.Notes,
                TotalAmount = dto.TotalAmount,
                IsPaid = dto.IsPaid,
                ModifiedDate = DateTime.Now
            };
        }

        /// <summary>
        /// Convert Entity to DisplayDto
        /// </summary>
        public static AppointmentsTienDmDisplayDto ToDisplayDto(this AppointmentsTienDm entity)
        {
            return new AppointmentsTienDmDisplayDto
            {
                AppointmentsTienDmid = entity.AppointmentsTienDmid,
                UserAccountId = entity.UserAccountId,
                ServicesNhanVtid = entity.ServicesNhanVtid,
                AppointmentStatusesTienDmid = entity.AppointmentStatusesTienDmid,
                AppointmentDate = entity.AppointmentDate,
                AppointmentTime = entity.AppointmentTime,
                SamplingMethod = entity.SamplingMethod,
                Address = entity.Address,
                ContactPhone = entity.ContactPhone,
                Notes = entity.Notes,
                CreatedDate = entity.CreatedDate,
                ModifiedDate = entity.ModifiedDate,
                TotalAmount = entity.TotalAmount,
                IsPaid = entity.IsPaid,
                StatusName = entity.AppointmentStatusesTienDm?.StatusName,
                ServiceName = entity.ServicesNhanVt?.ServiceName,
                UserName = entity.UserAccount?.UserName,
                UserEmail = entity.UserAccount?.Email
            };
        }

        /// <summary>
        /// Convert list of entities to display DTOs
        /// </summary>
        public static List<AppointmentsTienDmDisplayDto> ToDisplayDtos(this List<AppointmentsTienDm> entities)
        {
            return entities.Select(e => e.ToDisplayDto()).ToList();
        }

        /// <summary>
        /// Update existing entity with UpdateDto data
        /// </summary>
        public static void UpdateFromDto(this AppointmentsTienDm entity, UpdateAppointmentsTienDmDto dto)
        {
            entity.UserAccountId = dto.UserAccountId;
            entity.ServicesNhanVtid = dto.ServicesNhanVtid;
            entity.AppointmentStatusesTienDmid = dto.AppointmentStatusesTienDmid;
            entity.AppointmentDate = dto.AppointmentDate;
            entity.AppointmentTime = dto.AppointmentTime;
            entity.SamplingMethod = dto.SamplingMethod;
            entity.Address = dto.Address;
            entity.ContactPhone = dto.ContactPhone;
            entity.Notes = dto.Notes;
            entity.TotalAmount = dto.TotalAmount;
            entity.IsPaid = dto.IsPaid;
            entity.ModifiedDate = DateTime.Now;
        }
    }
}
