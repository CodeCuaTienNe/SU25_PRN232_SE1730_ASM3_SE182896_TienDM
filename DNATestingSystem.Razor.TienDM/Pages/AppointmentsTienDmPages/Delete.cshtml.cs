using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DNATestingSystem.Razor.TienDM.Services;
using DNATestingSystem.GrpcService.TienDM.Protos;

namespace DNATestingSystem.Razor.TienDM.Pages.AppointmentsTienDmPages
{
    public class DeleteModel : PageModel
    {
        private readonly AppointmentsTienDmGrpcService _grpcService;

        public DeleteModel(AppointmentsTienDmGrpcService grpcService)
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
                return Page();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var result = _grpcService.Delete(id.Value);
                if (result > 0)
                {
                    return RedirectToPage("./Index");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Error occurred while deleting the appointment");
            }

            return Page();
        }
    }
}
