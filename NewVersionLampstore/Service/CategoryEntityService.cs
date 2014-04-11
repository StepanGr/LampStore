using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewVersionLampstore.Service.Abstract;
using NewVersionLampstore.Models;

namespace NewVersionLampstore.Service
{
    public class CategoryEntityService : UrlFriendlyEntityService<Category>
    {
        LampaStoreEntities entities = new LampaStoreEntities();

        protected override System.Data.Objects.ObjectSet<Category> EntitySet { get { return entities.Categories; } }
    }
}