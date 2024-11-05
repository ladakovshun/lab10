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

                // �������� �� ���� �����
                if (request.Product == "������" && request.ConsultationDate.DayOfWeek == DayOfWeek.Monday)
                {
                    errorMessage = "������������ � �������� '������' �� ���� ��������� �� ���������.";
                    ModelState.AddModelError("ConsultationDate", errorMessage);
                }

                // �������� �� ���� � �����������
                if (request.ConsultationDate.Date <= DateTime.Now.Date)
                {
                    ModelState.AddModelError("ConsultationDate", "���� ������������ �� ���� � �����������.");
                }

                // �������� �� ������
                if (request.ConsultationDate.DayOfWeek == DayOfWeek.Saturday || request.ConsultationDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    ModelState.AddModelError("ConsultationDate", "������������ �� ���� ���� ���������� �� ������.");
                }

                if (!ModelState.IsValid)
                {
                    return View(request); // ��������� ����� � ���������
                }

                // ����� ��� ������� ������, ���� ��� ��������
                return RedirectToAction("Success");
            }

            return View(request); // ��������� ����� � ���������
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}



