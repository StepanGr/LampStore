using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace NewVersionLampstore.Models
{
    public class ContentManager
    {
        [Display(Name = "Логін")]
        [Required(ErrorMessage = "Логін Обовязково")]
        [RegularExpression("[a-z0-9_]+", ErrorMessage = "Тільки маленькі латинські букви і цифри")]
        public string Login { get; set; }

        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Пароль обовязково")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "мінімальна довжина 6 символів")]
        public string Password { get; set; }

        [Display(Name = "Повторіть пароль")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Повторіть пароль обовязково")]
        [Compare("Password", ErrorMessage = "пароль не співпадає")]
        public string Repeat { get; set; }

        [Display(Name = "Імя")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        
    }
}