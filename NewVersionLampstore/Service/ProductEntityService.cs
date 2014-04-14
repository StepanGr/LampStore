using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewVersionLampstore.Service.Abstract;
using NewVersionLampstore.Models;

namespace NewVersionLampstore.Service
{
    public class ProductEntityService:UrlFriendlyEntityService<Product>
    {
        LampaStoreEntities entities = new LampaStoreEntities();

        protected override System.Data.Objects.ObjectSet<Product> EntitySet { get { return entities.Products; } }


        public override IQueryable<Product> Get(System.Collections.Specialized.NameValueCollection filter, FilterData FilterCat)
        {
            IQueryable<Product> result = Get();
            
            
            if (!string.IsNullOrWhiteSpace(filter["find"]))
            {
                string strFind = filter["find"].ToLower();
                result = result.Where(item => item.Name != null && item.Name.Contains(strFind));
            }
            if (!string.IsNullOrWhiteSpace(filter["quantitylamps"]))
            {
                
                Category cat = new CategoryEntityService().Get(FilterCat.Category);
                string strFind = filter["quantitylamps"];
                 var res = cat.CategoryProducts.OrderByDescending(item => item.Sequence).Select(item=>item.Product);
                int quan=Convert.ToInt32(strFind);
                
                result = res.Where(item => item.QuantytiLamp == quan).AsQueryable();
                
            }
            return result;
        }
    }
}