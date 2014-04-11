using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NewVersionLampstore.Models.Interfaces;
using System.Collections.Specialized;

namespace NewVersionLampstore.Service.Interface
{
    public interface IBaseService<T>where T : class,IBase,new()
    {
        // Получение всех записей из таблицы БД
        IQueryable<T> Get();
        // Получение выбранных записей
        IQueryable<T> Get(NameValueCollection filter);

        // Получение количества всех записей
        int Count();

        // Получение количества выбранных записей
        int Count(NameValueCollection filter);

        // Получение одной записи с заданным ID
        T Get(int id);

        // Получение нескольких записей.
        // Параметр skip - сколько первых записей пропустить, параметр take - сколько записей получить
        IQueryable<T> Get(int skip, int take);

        // Получение нескольких выбранных записей
        IQueryable<T> Get(NameValueCollection filter, int skip, int take);

        // Добавление записи в таблицу
        void Create(T dataObject);

        // Редактирование записи таблицы
        void Update(T dataObject);

        // Удаление записи из таблицы
        void Delete(T dataObject);
    }
}
