using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;

namespace NewVersionLampstore.Helper
{
    public static class HtmlHelperExtensions
    {
    
    public static MvcHtmlString RenderJsToScriptBlock(this HtmlHelper htmlHelper,object model)
    {
      

      if (null == model) { return MvcHtmlString.Empty; }

      

      // use InnerHtml because it doesn't encode characters
      string sriliziation = htmlHelper.Raw(Json.Encode(model)).ToString();

      return new MvcHtmlString(sriliziation);
    }

    public static MvcHtmlString BackLink(this HtmlHelper helper, string defaultAction)
    {
        string returnUrl = HttpContext.Current.Request["returnUrl"];
        // If there's return url param redirect to there
        if (!String.IsNullOrEmpty(returnUrl))
        {
            return new MvcHtmlString("<a id=button_continue_shopping href=" + returnUrl + " >Продовжити покупку</a>");
        }

        // we didn't post anything so we can safely go back to previous url
        return new MvcHtmlString("<a id=button_continue_shopping href=" + HttpContext.Current.Request.UrlReferrer.ToString() + " >Продовжити покупку</a>");
    }
  }
    
}