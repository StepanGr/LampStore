using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NewVersionLampstore.Models.MetaDate
{
    public class CategoryMetaDate
    {
        [Required(ErrorMessage = "Назву обовязково")]
        [Display(Name = "Назва Категорії")]
        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Найменування в URL")]
        [RegularExpression("[a-z0-9_]+", ErrorMessage = "Тільки Маленькі латинські букви та цифри")]
        [StringLength(50)]
        public string ShortName { get; set; }
    }
}