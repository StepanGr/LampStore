using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewVersionLampstore.Models.Interfaces;
using NewVersionLampstore.Models.MetaDate;
using System.ComponentModel.DataAnnotations;

namespace NewVersionLampstore.Models
{
    [MetadataType(typeof(CategoryMetaDate))]
    public partial class Category:IUrlFriendly
    {
        public bool CanBeDeleted()
        {
            if (Collections.Count > 0) return false;

            if (CategoryProducts.Count > 0) return false;
            return true;
        }
    }
}