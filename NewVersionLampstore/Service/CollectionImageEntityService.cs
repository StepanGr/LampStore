using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewVersionLampstore.Service.Abstract;
using NewVersionLampstore.Models;

namespace NewVersionLampstore.Service
{
    public class CollectionImageEntityService : OrderEntityService<CollectionImage>
    {
        LampaStoreEntities entities = new LampaStoreEntities();

        protected override System.Data.Objects.ObjectSet<CollectionImage> EntitySet { get { return entities.CollectionImages; } }

        public override CollectionImage GetPrevious(CollectionImage dataObject)
        {
            return (from obj in EntitySet where obj.Sequence < dataObject.Sequence && obj.CollectionID == dataObject.CollectionID orderby obj.Sequence descending select obj).FirstOrDefault();
        }

        public override CollectionImage GetNext(CollectionImage dataObject)
        {
            return (from obj in EntitySet where obj.Sequence > dataObject.Sequence && obj.CollectionID == dataObject.CollectionID orderby obj.Sequence ascending select obj).FirstOrDefault();
        }
    }
}