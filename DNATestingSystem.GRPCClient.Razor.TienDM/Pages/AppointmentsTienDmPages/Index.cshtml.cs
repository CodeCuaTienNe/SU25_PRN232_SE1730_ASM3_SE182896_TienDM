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
    public class IndexModel : PageModel
    {
        private readonly AppointmentsTienDmGrpcService _grpcService;

        public IndexModel(AppointmentsTienDmGrpcService grpcService)
        {
            _grpcService = grpcService;
        }

        public IList<AppointmentsTienDm> AppointmentsTienDm { get; set; } = default!;

        public void OnGet()
        {
            AppointmentsTienDm = _grpcService.GetAll();
        }
    }
}
