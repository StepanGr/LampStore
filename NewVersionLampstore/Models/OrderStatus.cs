using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewVersionLampstore.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using NewVersionLampstore.Models.MetaDate;

namespace NewVersionLampstore.Models
{
    [MetadataType(typeof(OrderStatusMetadata))]
    public partial class OrderStatus : IOrdered
    {
        public bool CanBeDeleted()
        {
            return true;
        }
    }
}