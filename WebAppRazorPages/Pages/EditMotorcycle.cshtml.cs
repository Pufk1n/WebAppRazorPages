using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppRazorPages.Repository;
using WebAppRazorPages.Model;
using Microsoft.AspNetCore.Authorization;

namespace WebAppRazorPages.Pages
{
    [Authorize] // Разрешить доступ только аутентифицированным пользователям
    public class EditMotorcycleModel : PageModel
    {
        private readonly IMotorcycle _motorcycleRepository;

        public EditMotorcycleModel(IMotorcycle motorcycleRepository) => _motorcycleRepository = motorcycleRepository;

        public Motorcycle Motorcycle { get; set; }

        public IActionResult OnGet(int id)
        {
            Motorcycle = _motorcycleRepository.GetMotorcycle(id);
            Motorcycle ??= new Motorcycle();
            Console.WriteLine($"Received Motorcycle ID: {Motorcycle.Id}, Brand: {Motorcycle.BrandMotorcycle}, Model: {Motorcycle.Model}, Engine: {Motorcycle.EngineMotorcycle}");
            return Page();
        }

        public IActionResult OnPost(Motorcycle motorcycleForm)
        {
            Console.WriteLine($"Received Motorcycle ID: {motorcycleForm.Id}, Brand: {motorcycleForm.BrandMotorcycle}, Model: {motorcycleForm.Model}, Engine: {motorcycleForm.EngineMotorcycle}");
            Motorcycle = _motorcycleRepository.UpdateMotorcycle(motorcycleForm);

            if (Motorcycle == null)
                return NotFound();

            return RedirectToPage("Motorcycles");
        }
    }
}
