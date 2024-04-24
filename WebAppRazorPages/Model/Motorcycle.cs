using System.ComponentModel.DataAnnotations;

namespace WebAppRazorPages.Model
{
    public class Motorcycle
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите марку мотоцикла")]
        public string BrandMotorcycle { get; set; }
        [Required(ErrorMessage = "Введите модель")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Введите тип двигателя")]
        public string EngineMotorcycle { get; set; }

        public Motorcycle() 
        {
            BrandMotorcycle ??= string.Empty;
            Model ??= string.Empty;
            EngineMotorcycle ??= string.Empty;
        }
    }
}
