using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewVersionLampstore.Service.Abstract;
using NewVersionLampstore.Models;

namespace NewVersionLampstore.Service
{
    public class CategoryProductEntityService : OrderEntityService<CategoryProduct>
    {
        LampaStoreEntities entities = new LampaStoreEntities();

        protected override System.Data.Objects.ObjectSet<CategoryProduct> EntitySet { get { return entities.CategoryProducts; } }

        public override CategoryProduct GetPrevious(CategoryProduct dataObject)
        {
            return (from obj in EntitySet where obj.Sequence < dataObject.Sequence && obj.CategoryID == dataObject.CategoryID orderby obj.Sequence descending select obj).FirstOrDefault();
        }

        public override CategoryProduct GetNext(CategoryProduct dataObject)
        {
            return (from obj in EntitySet where obj.Sequence > dataObject.Sequence && obj.CategoryID == dataObject.CategoryID orderby obj.Sequence ascending select obj).FirstOrDefault();
        }
    }
}