using System.Xml.Linq;
using WebAppRazorPages.Model;

namespace WebAppRazorPages.Repository
{
    public class MocMotorcycleRepository : IMotorcycle
    {
        private List<Motorcycle> _motorcycle;
        public MocMotorcycleRepository() 
        {
            //if (_motorcycle == null) _motorcycle = new List<Motorcycle>(); эта строчка равно строчке 11
            _motorcycle ??= new List<Motorcycle>();
            _motorcycle.Add(new() { Id = 1, BrandMotorcycle = "Yamaha", Model = "R6" , EngineMotorcycle = "Бензиновый"});
            _motorcycle.Add(new() { Id = 2, BrandMotorcycle = "Honda", Model = "CB400", EngineMotorcycle = "Бензиновый" });
            _motorcycle.Add(new() { Id = 3, BrandMotorcycle = "Stels", Model = "Flex 250", EngineMotorcycle = "Бензиновый"});
        }
        public Motorcycle Add(Motorcycle Imotorcycle)
        {
            _motorcycle.Add(Imotorcycle);
            return Imotorcycle;
        }

        public Motorcycle DeleteMotorcycle(int Id)
        {
            var motorcycle = GetMotorcycle(Id);
            _ = _motorcycle.Remove(motorcycle);
            return motorcycle;
        }

        public Motorcycle? GetMotorcycle(int Id) 
        {
            return _motorcycle.Where(u => u.Id == Id).ToList().FirstOrDefault();
        }

        public List<Motorcycle> GetAll() 
        {
            return _motorcycle;
        }

        public Motorcycle UpdateMotorcycle(Motorcycle upMotorcycle)
        {
            var motorcycleDB = GetMotorcycle(upMotorcycle.Id);
            if (motorcycleDB != null)
            {
                _motorcycle.Remove(motorcycleDB);
            }
            _motorcycle.Add(upMotorcycle);
            return upMotorcycle;
        }

    }
}
