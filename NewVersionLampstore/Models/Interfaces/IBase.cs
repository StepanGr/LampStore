using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewVersionLampstore.Models.Interfaces
{
    public interface IBase
    {
        int ID { get; set; }
        bool CanBeDeleted();
        
    }
}
