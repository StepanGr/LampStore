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
    [MetadataType(typeof(CollectionMetadata))]
    public partial class Collection:IUrlFriendly
    {
        public bool CanBeDeleted()
        {
            if (CollectionImages.Count > 0) return false;
            if (CollectionProducts.Count > 0) return false;
            return true;
        }
    }
}