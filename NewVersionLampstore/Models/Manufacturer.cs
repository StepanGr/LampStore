using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using NewVersionLampstore.Models.MetaDate;
using System.Web.Mvc;
using NewVersionLampstore.Models.Interfaces;


namespace NewVersionLampstore.Models
{
    [MetadataType(typeof(ManefacturerMetaDate))]
    public partial class Manufacturer:IUrlFriendly
    {
        public bool CanBeDeleted()
        {
            if (Products.Count > 0) return false;
            return true;
        }
        
    }
}