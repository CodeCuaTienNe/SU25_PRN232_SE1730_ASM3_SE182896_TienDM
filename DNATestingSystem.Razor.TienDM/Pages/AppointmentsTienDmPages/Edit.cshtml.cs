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
    public class EditModel : PageModel
    {
        private readonly AppointmentsTienDmGrpcService _grpcService;

        public EditModel(AppointmentsTienDmGrpcService grpcService)
        {
            _grpcService = grpcService;
        }

        [BindProperty]
        public AppointmentsTienDm AppointmentsTienDm { get; set; } = default!;

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                AppointmentsTienDm = _grpcService.GetById(id.Value);
                if (AppointmentsTienDm == null)
                {
                    return NotFound();
                }
                // Note: You'll need to implement separate gRPC services for these lookups
                // or keep using EF Core for simple lookups
                return Page();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var result = _grpcService.Update(AppointmentsTienDm);
                if (result > 0)
                {
                    return RedirectToPage("./Index");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Error occurred while updating the appointment");
            }

            return Page();
        }
    }
}
