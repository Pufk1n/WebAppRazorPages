using WebAppRazorPages.Model;

namespace WebAppRazorPages.Repository
{
    public interface IMotorcycle
    {
        public Motorcycle Add(Motorcycle IMotorcycle);
        public Motorcycle? GetMotorcycle(int Id);
        public List<Motorcycle> GetAll();
        public Motorcycle UpdateMotorcycle(Motorcycle upMotorcycle);
        public Motorcycle DeleteMotorcycle(int Id);
    }
}
