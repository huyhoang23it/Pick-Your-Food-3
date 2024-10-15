using Food.Services;
using Food.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Food.Controllers
{
    public class FoodController : Controller
    {
        private readonly FoodService _foodService;
        private readonly SMSServices _smsService;
        public FoodController(FoodService foodService, SMSServices smsService)
        {
            _foodService = foodService;
            _smsService = smsService;
        }

        public async Task<IActionResult> Index()
        {
            var foods = await _foodService.GetAllFoodsAsync();
            return View(foods);
        }
        [HttpPost]
        public IActionResult SendOrder(List<int> selectedFoods, string phoneNumber)
        {     
            var message = "Bạn đã chọn các món ăn: ";

            // Gửi tin nhắn đến số điện thoại
            _smsService.SendSms(phoneNumber, message);

            // Trả về thông báo thành công
            TempData["SuccessMessage"] = "Đơn hàng đã được gửi thành công đến số điện thoại " + phoneNumber;
            return RedirectToAction("Index");
        }

    }
}
