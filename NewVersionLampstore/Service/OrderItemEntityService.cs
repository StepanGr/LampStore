using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewVersionLampstore.Service.Abstract;
using NewVersionLampstore.Models;

namespace NewVersionLampstore.Service
{
    public class OrderItemEntityService : BaseEntityService<OrderItem>
    {
        LampaStoreEntities entities = new LampaStoreEntities();

        protected override System.Data.Objects.ObjectSet<OrderItem> EntitySet
        {
            get { return entities.OrderItems; }
        }
    }
}