using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DNATestingSystem.Razor.TienDM.Services;
using DNATestingSystem.GrpcService.TienDM.Protos;

namespace DNATestingSystem.Razor.TienDM.Pages.AppointmentsTienDmPages
{
    public class CreateModel : PageModel
    {
        private readonly AppointmentsTienDmGrpcService _grpcService;

        public CreateModel(AppointmentsTienDmGrpcService grpcService)
        {
            _grpcService = grpcService;
        }

        public IActionResult OnGet()
        {
            // Note: You'll need to implement separate gRPC services for these lookups
            // or keep using EF Core for simple lookups
            return Page();
        }

        [BindProperty]
        public AppointmentsTienDm AppointmentsTienDm { get; set; } = default!;

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Ensure CreatedDate and ModifiedDate are set to current UTC time in ISO 8601 format
            var now = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            AppointmentsTienDm.CreatedDate = now;
            AppointmentsTienDm.ModifiedDate = now;

            try
            {
                var result = _grpcService.Create(AppointmentsTienDm);
                if (result > 0)
                {
                    return RedirectToPage("./Index");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Error occurred while creating the appointment");
            }

            return Page();
        }
    }
}
