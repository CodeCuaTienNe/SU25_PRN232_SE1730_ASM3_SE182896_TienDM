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
    public class DetailsModel : PageModel
    {
        private readonly AppointmentsTienDmGrpcService _grpcService;

        public DetailsModel(AppointmentsTienDmGrpcService grpcService)
        {
            _grpcService = grpcService;
        }

        public AppointmentsTienDm AppointmentsTienDm { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var appointment = await _grpcService.GetByIdAsync(id.Value);
                if (appointment == null)
                {
                    return NotFound();
                }
                AppointmentsTienDm = appointment;
                return Page();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
