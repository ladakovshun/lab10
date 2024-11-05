using System;
using WebApplication10.Models;

namespace WebApplication10.Services
{
    public interface IConsultationService
    {
        bool IsValidConsultationDate(ConsultationRequest request, out string errorMessage);
    }

    public class ConsultationService : IConsultationService
    {
        public bool IsValidConsultationDate(ConsultationRequest request, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (request.Product == "Основи" && request.ConsultationDate.DayOfWeek == DayOfWeek.Monday)
            {
                errorMessage = "Консультація з продукту 'Основи' не може проходити по понеділках.";
                return false;
            }

            return true;
        }
    }
}
