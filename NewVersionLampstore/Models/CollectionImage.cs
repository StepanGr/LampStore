using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewVersionLampstore.Models.Interfaces;

namespace NewVersionLampstore.Models
{
    public partial class CollectionImage : IOrdered
    {
        public bool CanBeDeleted()
        {
            return true;
        }

    }
}