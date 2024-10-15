using Led.Models;
using Microsoft.AspNetCore.Mvc;

namespace Led.Controllers
{
    public class LedController : Controller
    {
        private readonly LedContext _context;

        public LedController(LedContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var model = _context.LED_state.FirstOrDefault();
            return View(model);
        }

        // 新增這個方法來接收前端的POST請求
        [HttpPost]
        [Route("/")]  // 匹配 /led 路徑的 POST 請求
        public IActionResult UpdateLedStatus([FromBody] LedStatusModel model)
        {
            Console.WriteLine($"Received LED status: {model.Status}");

            var ledstate = _context.LED_state.FirstOrDefault();
            if (ledstate != null)
            {
                ledstate.state = model.Status;

                // 提交更改到資料庫
                _context.SaveChanges();
                return Ok(new { message = "LED status updated successfully" });
            }

            
            return NotFound(new { message = "LED state record not found" });
        }

        // LED狀態的模型，用來接收從前端傳來的數據
        public class LedStatusModel
        {
            public string Status { get; set; }
        }
    }
}
