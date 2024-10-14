using APIFood.Models;

namespace APIFood.Repository
{
    public interface IFoodRepository
    {
        IEnumerable<Food> GetAllFoods();
    }
}
