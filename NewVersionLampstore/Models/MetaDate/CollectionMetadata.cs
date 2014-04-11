using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NewVersionLampstore.Models.MetaDate
{
    public class CollectionMetadata
    {
        [Required(ErrorMessage = "Найменування обовязково")]
        [Display(Name = "Найменування")]
        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Найменування выдображене в URL")]
        [RegularExpression("[a-z0-9_]+", ErrorMessage = "Тільки маленькі латинські букви цифри і підчеркування ")]
        [StringLength(50)]
        public string ShortName { get; set; }

        [Display(Name = "Опис")]
        public string Description { get; set; }

        [Display(Name = "Категорія")]
        [Required(ErrorMessage = "Категорія обовязково")]
        public int? CategoryID { get; set; }
    }
}