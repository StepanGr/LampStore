using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewVersionLampstore.Service.Interface;
using NewVersionLampstore.Models.Interfaces;

namespace NewVersionLampstore.Service.Abstract
{
    public abstract class UrlFriendlyEntityService<T> :OrderEntityService<T>,IUrlFriendlyService<T> where T:class,IUrlFriendly,new()
    {
        // Получение объекта по его краткому имени
        public virtual T Get(string shortName)
        {
            var obje = EntitySet.Where(p => p.ShortName == shortName).FirstOrDefault();
            return obje;
        }
        public virtual string CreateUniqueShortName(int id, string shortName)
        {
            string strResult = shortName.ToLower();

            int? iMaxID = Get().OrderByDescending(item => item.ID).Select(item => item.ID).FirstOrDefault();
            string strAffix = iMaxID.HasValue ? iMaxID.Value.ToString() : "1";
            if (string.IsNullOrWhiteSpace(shortName)) strResult = strAffix;

            int iCount = Get().Where(item => item.ShortName.ToLower() == strResult && item.ID != id).Count();
            if (iCount > 0) strResult = string.Format("{0}{1}", shortName, strAffix);
            if (Constants.RESERVED_WORDS.Contains(strResult)) strResult = string.Format("{0}{1}", strResult, strAffix);

            return strResult;
        }
    }
}