using System;
using System.ComponentModel.DataAnnotations;

namespace DNATestingSystem.Repository.TienDM.ModelExtensions
{
    /// <summary>
    /// DTO for creating new appointments - only includes necessary fields for input
    /// </summary>
    public class CreateAppointmentsTienDmDto
    {
        [Required(ErrorMessage = "User Account is required")]
        public int UserAccountId { get; set; }

        [Required(ErrorMessage = "Service selection is required")]
        public int ServicesNhanVtid { get; set; }

        [Required(ErrorMessage = "Appointment status is required")]
        public int AppointmentStatusesTienDmid { get; set; }

        [Required(ErrorMessage = "Appointment date is required")]
        public DateOnly AppointmentDate { get; set; }

        [Required(ErrorMessage = "Appointment time is required")]
        public TimeOnly AppointmentTime { get; set; }

        [Required(ErrorMessage = "Sampling method is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Sampling method must be between 3 and 100 characters")]
        public string SamplingMethod { get; set; } = null!;

        [StringLength(250, ErrorMessage = "Address cannot exceed 250 characters")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Contact phone is required")]
        [Phone(ErrorMessage = "Please enter a valid phone number")]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "Contact phone must be between 10 and 15 characters")]
        public string ContactPhone { get; set; } = null!;

        [StringLength(500, ErrorMessage = "Notes cannot exceed 500 characters")]
        public string? Notes { get; set; }

        [Required(ErrorMessage = "Total amount is required")]
        [Range(0.01, 999999.99, ErrorMessage = "Total amount must be between 0.01 and 999,999.99")]
        public decimal TotalAmount { get; set; }

        public bool? IsPaid { get; set; } = false;
    }

    /// <summary>
    /// DTO for updating appointments - includes ID and fields that can be updated
    /// </summary>
    public class UpdateAppointmentsTienDmDto
    {
        [Required(ErrorMessage = "Appointment ID is required")]
        public int AppointmentsTienDmid { get; set; }

        [Required(ErrorMessage = "User Account is required")]
        public int UserAccountId { get; set; }

        [Required(ErrorMessage = "Service selection is required")]
        public int ServicesNhanVtid { get; set; }

        [Required(ErrorMessage = "Appointment status is required")]
        public int AppointmentStatusesTienDmid { get; set; }

        [Required(ErrorMessage = "Appointment date is required")]
        public DateOnly AppointmentDate { get; set; }

        [Required(ErrorMessage = "Appointment time is required")]
        public TimeOnly AppointmentTime { get; set; }

        [Required(ErrorMessage = "Sampling method is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Sampling method must be between 3 and 100 characters")]
        public string SamplingMethod { get; set; } = null!;

        [StringLength(250, ErrorMessage = "Address cannot exceed 250 characters")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Contact phone is required")]
        [Phone(ErrorMessage = "Please enter a valid phone number")]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "Contact phone must be between 10 and 15 characters")]
        public string ContactPhone { get; set; } = null!;

        [StringLength(500, ErrorMessage = "Notes cannot exceed 500 characters")]
        public string? Notes { get; set; }

        [Required(ErrorMessage = "Total amount is required")]
        [Range(0.01, 999999.99, ErrorMessage = "Total amount must be between 0.01 and 999,999.99")]
        public decimal TotalAmount { get; set; }

        public bool? IsPaid { get; set; }
    }

    /// <summary>
    /// DTO for displaying appointment details - includes navigation properties for display
    /// </summary>
    public class AppointmentsTienDmDisplayDto
    {
        public int AppointmentsTienDmid { get; set; }
        public int UserAccountId { get; set; }
        public int ServicesNhanVtid { get; set; }
        public int AppointmentStatusesTienDmid { get; set; }
        public DateOnly AppointmentDate { get; set; }
        public TimeOnly AppointmentTime { get; set; }
        public string SamplingMethod { get; set; } = null!;
        public string? Address { get; set; }
        public string ContactPhone { get; set; } = null!;
        public string? Notes { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public decimal TotalAmount { get; set; }
        public bool? IsPaid { get; set; }

        // Navigation properties for display
        public string? StatusName { get; set; }
        public string? ServiceName { get; set; }
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }
    }
}
