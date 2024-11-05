using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication10.Models
{
    public class ConsultationRequest
    {
        [Required(ErrorMessage = "Ім'я та прізвище є обов'язковим полем.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email є обов'язковим полем.")]
        [EmailAddress(ErrorMessage = "Email має бути у відповідному форматі.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Дата консультації є обов'язковим полем.")]
        [DataType(DataType.Date)]
        [FutureDate(ErrorMessage = "Дата має бути в майбутньому.")]
        [WeekdayValidation(ErrorMessage = "Дата не може бути у вихідний день.")]
        public DateTime ConsultationDate { get; set; }

        [Required(ErrorMessage = "Оберіть продукт.")]
        public string Product { get; set; }
    }
    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime date)
            {
                return date > DateTime.Now;
            }
            return false;
        }
    }

    public class WeekdayValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime date)
            {
                return date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday;
            }
            return false;
        }
    }
}
