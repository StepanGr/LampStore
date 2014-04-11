using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewVersionLampstore.Service.Abstract;
using NewVersionLampstore.Models;

namespace NewVersionLampstore.Service
{
    public class OrderStatusEntityService : OrderEntityService<OrderStatus>
    {
        LampaStoreEntities entities = new LampaStoreEntities();

        protected override System.Data.Objects.ObjectSet<OrderStatus> EntitySet
        {
            get { return entities.OrderStatuses; }
        }
    }
}