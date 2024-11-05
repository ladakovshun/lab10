using Microsoft.AspNetCore.Mvc;
using WebApplication10.Models;


namespace WebApplication10.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Register()
        {
            return View(new ConsultationRequest());
        }

        [HttpPost]
        public IActionResult Register(ConsultationRequest request)
        {
            if (ModelState.IsValid)
            {
                string errorMessage = string.Empty;

                // Перевірка на день тижня
                if (request.Product == "Основи" && request.ConsultationDate.DayOfWeek == DayOfWeek.Monday)
                {
                    errorMessage = "Консультація з продукту 'Основи' не може проходити по понеділках.";
                    ModelState.AddModelError("ConsultationDate", errorMessage);
                }

                // Перевірка на дату в майбутньому
                if (request.ConsultationDate.Date <= DateTime.Now.Date)
                {
                    ModelState.AddModelError("ConsultationDate", "Дата консультації має бути в майбутньому.");
                }

                // Перевірка на вихідні
                if (request.ConsultationDate.DayOfWeek == DayOfWeek.Saturday || request.ConsultationDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    ModelState.AddModelError("ConsultationDate", "Консультація не може бути призначена на вихідні.");
                }

                if (!ModelState.IsValid)
                {
                    return View(request); // Повертаємо форму з помилками
                }

                // Логіка для обробки запиту, якщо все коректно
                return RedirectToAction("Success");
            }

            return View(request); // Повертаємо форму з помилками
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}



