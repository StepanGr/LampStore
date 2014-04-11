using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NewVersionLampstore.Models
{
    public class ShipInfo
    {
        [Display(Name = "Імя")]
        public string Name { get; set; }
        [Display(Name = "Фамілія")]
        public string LastName { get; set; }
        [Display(Name = "Телефон")]
        public string Phone { get; set; }
        [Display(Name = "Тип Оплати")]
        public string typePayment { get; set; }
        [Display(Name = "Тип Доставки")]
        public string typeShipped { get; set; }
        [Display(Name = "Місто")]
        public string Citi { get; set; }
        [Display(Name = "Електрона пошта")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }

  
}