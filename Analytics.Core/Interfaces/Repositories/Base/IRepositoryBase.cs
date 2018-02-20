using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Analytics.Core.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<T, ID>
        where T : class
        where ID : struct
    {
        IQueryable<T> ListBy(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> ListAndOrderBy<TKey>(Expression<Func<T, bool>> where, Expression<Func<T, TKey>> ordem, bool ascendente = true, params Expression<Func<T, object>>[] includeProperties);

        T GetBy(Func<T, bool> where, params Expression<Func<T, object>>[] includeProperties);

        bool Exists(Func<T, bool> where);

        IQueryable<T> List(params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> ListOrderBy<TKey>(Expression<Func<T, TKey>> ordem, bool ascendente = true, params Expression<Func<T, object>>[] includeProperties);

        T GetById(ID id, params Expression<Func<T, object>>[] includeProperties);

        T Add(T entity);

        T Update(T entity);

        void Remove(T entity);

        IEnumerable<T> AddList(IEnumerable<T> entidades);
    }
}
