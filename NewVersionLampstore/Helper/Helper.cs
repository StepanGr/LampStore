using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;

namespace NewVersionLampstore.Helper
{
    public static class Helper
    {
        public static List<string> GetUrlPath(HttpRequestBase request)
        {
            List<string> result = new List<string>();

            string[] segments = request.Url.Segments;

            foreach (string segment in segments)
            {
                string curSeg = segment.Replace("/", "");
                if (!string.IsNullOrWhiteSpace(curSeg)) result.Add(curSeg);
            }

            return result;
        }
    }
}