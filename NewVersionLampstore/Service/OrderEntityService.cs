using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewVersionLampstore.Service.Abstract;
using NewVersionLampstore.Models;

namespace NewVersionLampstore.Service
{
    public class OrderEntityService : BaseEntityService<Order>
    {
        LampaStoreEntities entities = new LampaStoreEntities();

        protected override System.Data.Objects.ObjectSet<Order> EntitySet
        {
            get { return entities.Orders; }
        }

        public override IQueryable<Order> Get()
        {
            return base.Get().OrderByDescending(item => item.Date);
        }
    }
}