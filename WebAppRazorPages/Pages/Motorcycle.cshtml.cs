using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppRazorPages.Repository;
using WebAppRazorPages.Model;

namespace WebAppRazorPages.Pages
{
    public class MotorcycleModel : PageModel
    {
        public MotorcycleModel(IMotorcycle motorcycleRepository)
        {
            _motorcycleRepository = motorcycleRepository;
        }

        private IMotorcycle _motorcycleRepository;
        public Motorcycle? Motorcycle { get; set; }
        public IActionResult OnGet(int id_motorcycle)
        {
            Motorcycle = _motorcycleRepository.GetMotorcycle(id_motorcycle);
            if (Motorcycle == null) return NotFound(); 
            return Page();
        }
    }
}
