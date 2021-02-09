using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //generic constraint = generic kısıt
    //T ya IEntity olabilir yada IEntity implemente eden bir nesne olabilir.
    //class:referans tip olabilir.
    //new() :new'lenebilir olmalı
    public interface IEntityRepository<T>where T:class,IEntity,new()
    {
        //Expression istedğimiz categoryId olsun herhangi bir başka ilişkilerideki filtreyebilirz ,getirebiliriz delegedir.
        //Yani istediğimiz filtreleme işlemlerini yazabilmemizi sağlamaktadır,2500 tl aşşağısını getir,en çok satan getir vb gibi.
        //Filtre verilmeyebilirsin
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
