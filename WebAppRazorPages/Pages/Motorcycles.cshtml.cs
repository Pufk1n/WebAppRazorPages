using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppRazorPages.Repository;
using WebAppRazorPages.Model;

namespace WebAppRazorPages.Pages
{
    public class MotorcyclesModel : PageModel
    {
        public MotorcyclesModel(IMotorcycle motorcycleRepository)
        {
            _motorcycleRepository = motorcycleRepository;
        }

        private IMotorcycle _motorcycleRepository;
        public List<Motorcycle> motorcycle { get; set; }
        public IActionResult OnGet()
        {
            motorcycle = _motorcycleRepository.GetAll();
            return Page();
        }
        public IActionResult OnPost(int id)
        {
            _motorcycleRepository.DeleteMotorcycle(id);
            return RedirectToPage();
        }
    }
}
