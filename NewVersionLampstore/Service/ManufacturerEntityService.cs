using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewVersionLampstore.Models;
using NewVersionLampstore.Service.Interface;
using NewVersionLampstore.Service.Abstract;


namespace NewVersionLampstore.Service
{
    public class ManufacturerEntityService : UrlFriendlyEntityService<Manufacturer>
    {
        LampaStoreEntities entities = new LampaStoreEntities();

        protected override System.Data.Objects.ObjectSet<Manufacturer> EntitySet { get { return entities.Manufacturers; } }
    }
}