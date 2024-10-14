using APIFood.Models;

namespace APIFood.Repository
{
    public class FoodRepository : IFoodRepository
    {
        private readonly FoodContext _context = new FoodContext();

        public IEnumerable<Food> GetAllFoods()
        {
            return _context.Foods.ToList();
        }
    }
}
