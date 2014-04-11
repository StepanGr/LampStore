using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace NewVersionLampstore.Models.MetaDate
{
    public class ProductMetaDate
    {


        [Required(ErrorMessage = "Найменування Обовязково")]
        [Display(Name = "Найменування Товару")]
        [StringLength(50, ErrorMessage = "Не більше 50 сиволів")]
        public string Name { get; set; }

        [Display(Name = "Найменування яке відображаеться в Url")]
        [RegularExpression("[a-z0-9_]+", ErrorMessage = "Тільки маленькі латинські букви цифри і підчеркування ")]
        public string ShortName { get; set; }

        [Required(ErrorMessage = "Ціна Обовязкова")]
        [Display(Name = "Ціна")]
        public string Price { get; set; }

        [Required(ErrorMessage = "Виробник Обовязково")]
        [Display(Name = "Виробник")]
        public string ManufacturerID { get; set; }

        [HiddenInput(DisplayValue=false)]
        public int ID { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int Rating { get; set; }

        [Display(Name = "Висота см")]
        public int height { get; set; }

        [Display(Name = "Ширина(Діаметр) см")]
        public int width { get; set; }

        [Display(Name = "Тип патрона")]
        public string cap { get; set; }

        [Display(Name = "Потужність лампочки")]
        public string MaxWatt { get; set; }

        [Display(Name = "Колір")]
        public string Color { get; set; }

        [Display(Name = "Кількість лампочок")]
        public string QuantytiLamp { get; set; }
    }
}