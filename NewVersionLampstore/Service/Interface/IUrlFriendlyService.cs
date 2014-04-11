using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NewVersionLampstore.Models.Interfaces;

namespace NewVersionLampstore.Service.Interface
{
   public interface IUrlFriendlyService<T>:IOrderService<T> where T: class, IUrlFriendly,new()
    {
        // Получение объекта по краткому наименованию	
        T Get(string shortName);

        // Проверка краткого имени на уникальность и приведение его к уникальному виду
        string CreateUniqueShortName(int id, string shortName);
    }
}
