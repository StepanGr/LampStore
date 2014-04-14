using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Objects;
using NewVersionLampstore.Models.Interfaces;
using NewVersionLampstore.Service.Interface;
using System.Collections.Specialized;
using NewVersionLampstore.Models;

namespace NewVersionLampstore.Service.Abstract
{
    public abstract class BaseEntityService<T>:IBaseService<T> where T: class, IBase, new()
    {
        // Объект Entity Framework
        protected abstract ObjectSet<T> EntitySet { get; }

        // Получение полного списка объектов
        public virtual IQueryable<T> Get()
        {
            return from obj in EntitySet select obj;
        }
        public virtual IQueryable<T> Get(NameValueCollection filter)
        {
            return Get();
        }

        // Получение списка выбранных объектов
        public virtual IQueryable<T> Get(NameValueCollection filter, FilterData FilterCat)
        {
            return Get();
        }

        
        // Получение количества всех объектов
        public virtual int Count()
        {
            return Get().Count();
        }

        // Получение количества выбранных объектов
        public virtual int Count(NameValueCollection filter)
        {
            return Get(filter).Count();
        }

        // Получение объекта по его ID
        public virtual T Get(int id)
        {
            return (from obj in EntitySet where obj.ID == id select obj).FirstOrDefault();
        }

        

        // Получение неполного списка объекта
        // skip - сколько первых записей пропустить, take - сколько записей получить
        public virtual IQueryable<T> Get(int skip, int take)
        {
            return Get().Skip(skip).Take(take);
        }
        // Получение неполного списка выбранных объектов
        public virtual IQueryable<T> Get(NameValueCollection filter, int skip, int take)
        {
            return Get(filter).Skip(skip).Take(take);
        }
        public virtual IQueryable<T> Get(NameValueCollection filter,FilterData FilterCat, int skip, int take)
        {
            return Get(filter,FilterCat).Skip(skip).Take(take);
        }
        // Добавление объекта
        public virtual void Create(T dataObject)
        {
            EntitySet.AddObject(dataObject);
            EntitySet.Context.SaveChanges();
        }

        // Сохранение изменений в объекте
        public virtual void Update(T dataObject)
        {
            EntitySet.Context.SaveChanges();
        }

        // Удаление объекта
        public virtual void Delete(T dataObject)
        {
            EntitySet.DeleteObject(dataObject);
            EntitySet.Context.SaveChanges();
        }
    }
}