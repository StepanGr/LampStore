using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using NewVersionLampstore.Models.MetaDate;
using NewVersionLampstore.Models.Interfaces;

namespace NewVersionLampstore.Models
{
    [MetadataType(typeof(ProductMetaDate))]
    public partial class Product:IUrlFriendly
    {
        
        public bool CanBeDeleted()
        {
            if (CategoryProducts.Count > 0) return false;

            if (CollectionProducts.Count > 0) return false;
            return true;

        }
        
    }
}