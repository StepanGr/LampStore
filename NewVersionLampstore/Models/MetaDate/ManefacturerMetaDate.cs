using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace NewVersionLampstore.Models.MetaDate
{
    public class ManefacturerMetaDate
    {
        [HiddenInput(DisplayValue = false)]
        public  int ID { get; set; }
        [Required(ErrorMessage = "Найменування Обовязково")]
        [Display(Name = "Найменування")]
        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Опис")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Наименование отображаемое в URL")]
        [RegularExpression("[a-z0-9_]+", ErrorMessage = "Тільки маленькі латинські букви цифри і підчеркування")]
        [StringLength(50)]
        public string ShortName { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int? Sequence { get; set; }
        
    }
}