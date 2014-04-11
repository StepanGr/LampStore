using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewVersionLampstore.Service.Abstract;
using NewVersionLampstore.Models;

namespace NewVersionLampstore.Service
{
    public class CollectionEntityService : UrlFriendlyEntityService<Collection>
    {
        LampaStoreEntities entities = new LampaStoreEntities();

        protected override System.Data.Objects.ObjectSet<Collection> EntitySet { get { return entities.Collections; } }

        public override Collection GetPrevious(Collection dataObject)
        {
            return (from obj in EntitySet where obj.Sequence < dataObject.Sequence && obj.CategoryID == dataObject.CategoryID orderby obj.Sequence descending select obj).FirstOrDefault();
        }

        public override Collection GetNext(Collection dataObject)
        {
            return (from obj in EntitySet where obj.Sequence > dataObject.Sequence && obj.CategoryID == dataObject.CategoryID orderby obj.Sequence ascending select obj).FirstOrDefault();
        }
    }
}