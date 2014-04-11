using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewVersionLampstore.Service.Abstract;
using NewVersionLampstore.Models;

namespace NewVersionLampstore.Service
{
    public class CollectionProductEntityService : OrderEntityService<CollectionProduct>
    {
        LampaStoreEntities entities = new LampaStoreEntities();

        protected override System.Data.Objects.ObjectSet<CollectionProduct> EntitySet { get { return entities.CollectionProducts; } }

        public override CollectionProduct GetPrevious(CollectionProduct dataObject)
        {
            return (from obj in EntitySet where obj.Sequence < dataObject.Sequence && obj.CollectionID == dataObject.CollectionID orderby obj.Sequence descending select obj).FirstOrDefault();
        }

        public override CollectionProduct GetNext(CollectionProduct dataObject)
        {
            return (from obj in EntitySet where obj.Sequence > dataObject.Sequence && obj.CollectionID == dataObject.CollectionID orderby obj.Sequence ascending select obj).FirstOrDefault();
        }
    }
}