using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewVersionLampstore.Service.Interface;
using NewVersionLampstore.Models.Interfaces;

namespace NewVersionLampstore.Service.Abstract
{
    public abstract class OrderEntityService<T> : BaseEntityService<T>, IOrderService<T> where T:class,IOrdered,new()
    {

        // В списке объекты должны располагаться в порядке уменьшения Sequence
        public override IQueryable<T> Get()
        {
            return base.Get().OrderByDescending(item => item.Sequence);
        }

        // Получение ближайшего объекта с меньшим Sequence
        public virtual T GetPrevious(T dataObject)
        {
            return (from obj in EntitySet where obj.Sequence < dataObject.Sequence orderby obj.Sequence descending select obj).FirstOrDefault();
        }

        // Получение ближайшего объекта с большим Sequence
        public virtual T GetNext(T dataObject)
        {
            return (from obj in EntitySet where obj.Sequence > dataObject.Sequence orderby obj.Sequence ascending select obj).FirstOrDefault();
        }

        // Получение максимального значения Sequence из всех объектов
        public virtual int? GetMaxSequence()
        {
            return Get().OrderByDescending(item => item.Sequence).Select(item => item.Sequence).FirstOrDefault();
        }

    }
}