using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewVersionLampstore.Models;

namespace NewVersionLampstore.Binders
{
    public class UserSessionDataBinder : IModelBinder
    {
        public Object BindModel(ControllerContext controlerContext, ModelBindingContext bindingContext)
        {
            FilterData Filter = (FilterData)controlerContext.HttpContext.Session[NewVersionLampstore.Constants.SESSION_FILTER];
            if (Filter == null)
            {
                Filter = new FilterData();
                controlerContext.HttpContext.Session[NewVersionLampstore.Constants.SESSION_FILTER] = Filter;

            }
            
           return Filter;
        }
    }
}