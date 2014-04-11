using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NewVersionLampstore.Models.MetaDate
{
    public class OrderStatusMetadata
    {
        
            [Required(ErrorMessage = "*")]
            public string Name { get; set; }
        
    }
}