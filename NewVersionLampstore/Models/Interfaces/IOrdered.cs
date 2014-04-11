using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace NewVersionLampstore.Models.Interfaces
{
    public interface IOrdered:IBase
    {
        
        int? Sequence { get; set; }
    }
}
