using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NewVersionLampstore.Models.Interfaces;

namespace NewVersionLampstore.Service.Interface
{
   public interface IOrderService<T>:IBaseService<T> where T:class,IOrdered,new()
    {
        // Получение ближайшего объекта с меньшим Sequence
        T GetPrevious(T dataObject);

        // Получение ближайшего объекта с большим Sequence
        T GetNext(T dataObject);

        // Получение максимального значения Sequence из всех объектов
        int? GetMaxSequence();
    }
}
