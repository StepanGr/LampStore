using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewVersionLampstore.Models
{
    public class FilterData
    {
        public string Category { get; set; }
        public string QuantityLamp { get; set; }
        public decimal price { get; set; }
        public string height { get; set; }
        public string width { get; set; }
        public List<int> LastViews { get; set; }
    }
}