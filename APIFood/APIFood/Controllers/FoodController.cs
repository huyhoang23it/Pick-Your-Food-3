using APIFood.Models;
using APIFood.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIFood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodRepository _foodrepository;

        public FoodController(IFoodRepository foodRepository)
        {
            _foodrepository = foodRepository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Food>> GetFoods()
        {
            var result = _foodrepository.GetAllFoods();
            if (result == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(result);
            }
        }
    }
}
