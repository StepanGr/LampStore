using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewVersionLampstore.Models.Interfaces;
using NewVersionLampstore.Service.Interface;

namespace NewVersionLampstore.Controllers.Abstract
{
    public abstract class OrderController<T, S> : BaseController<T, S>
        where T : class,IOrdered, new()
        where S : IOrderService<T>
    {
        public OrderController(S _service) : base(_service) { }
        #region Actions

        // Перемещение объекта вверх
        [Authorize(Roles = Constants.ROLES_ADMIN_CONTENT_MANAGER)]
        public ActionResult Up(int id)
        {
            T obj = service.Get(id);

            if (obj == null) return View("NotFound");
            else
            {
                if (obj.Sequence.HasValue)
                {
                    T next = service.GetNext(obj);

                    if (next != null)
                    {
                        int? curSeq = obj.Sequence;
                        int? nextSeq = next.Sequence;

                        obj.Sequence = nextSeq;
                        service.Update(obj);
                        next.Sequence = curSeq;
                        service.Update(next);
                    }
                }

                return OnUp(obj);
            }
        }
        // Перемещение объекта вниз
        [Authorize(Roles = Constants.ROLES_ADMIN_CONTENT_MANAGER)]
        public ActionResult Down(int id)
        {
            T obj = service.Get(id);

            if (obj == null) return View("NotFound");
            else
            {
                if (obj.Sequence.HasValue)
                {
                    T previous = service.GetPrevious(obj);

                    if (previous != null)
                    {
                        int? curSeq = obj.Sequence;
                        int? prevSeq = previous.Sequence;

                        obj.Sequence = prevSeq;
                        service.Update(obj);
                        previous.Sequence = curSeq;
                        service.Update(previous);
                    }
                }

                return OnDown(obj);
            }


        }
        #endregion
        #region Virtual methods

        // Перенаправление после перемещения объекта вверх
        protected virtual ActionResult OnUp(T obj)
        {
            return ReturnToList(obj);
        }

        // Перенаправление после перемещения объекта вниз
        protected virtual ActionResult OnDown(T obj)
        {
            return ReturnToList(obj);
        }

        #endregion

        #region Overridden virtual methods

        // При создании объекта автоматически задаём ему значение Sequence, равное следующему после наибольшего
        protected override void AddValuesOnCreate(T obj)
        {
            base.AddValuesOnCreate(obj);

            int? iMaxSequence = service.GetMaxSequence();
            obj.Sequence = iMaxSequence.HasValue ? iMaxSequence.Value + 1 : 1;
        }

        #endregion
    }
}
