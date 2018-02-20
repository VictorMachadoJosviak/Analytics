using Analytics.Core.Interfaces.Repositories.Base;
using Analytics.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Analytics.Infra.Repositories.Base
{
    public class RepositoryBase<T, ID> : IRepositoryBase<T, ID> where ID :struct  
        where T : EntityBase
    {
        private readonly DbContext _context;

        public RepositoryBase(DbContext context)
        {
            _context = context;
        }

        public IQueryable<T> ListBy(System.Linq.Expressions.Expression<Func<T, bool>> where, params System.Linq.Expressions.Expression<Func<T, object>>[] includeProperties)
        {
            return List(includeProperties).Where(where);
        }

        public IQueryable<T> ListAndOrderBy<TKey>(System.Linq.Expressions.Expression<Func<T, bool>> where, System.Linq.Expressions.Expression<Func<T, TKey>> ordem, bool ascendente = true, params System.Linq.Expressions.Expression<Func<T, object>>[] includeProperties)
        {
            return ascendente ? ListBy(where, includeProperties).OrderBy(ordem) : ListBy(where, includeProperties).OrderByDescending(ordem);
        }

        public T GetBy(Func<T, bool> where, params System.Linq.Expressions.Expression<Func<T, object>>[] includeProperties)
        {
            return List(includeProperties).FirstOrDefault(where);
        }

        public bool Exists(Func<T, bool> where)
        {
            return _context.Set<T>().Any(where);
        }

        public IQueryable<T> List(params System.Linq.Expressions.Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includeProperties.Any())
            {
                return Include(_context.Set<T>(), includeProperties);
            }

            return query;
        }

        public IQueryable<T> ListOrderBy<TKey>(System.Linq.Expressions.Expression<Func<T, TKey>> ordem, bool ascendente = true, params System.Linq.Expressions.Expression<Func<T, object>>[] includeProperties)
        {
            return ascendente ? List(includeProperties).OrderBy(ordem) : List(includeProperties).OrderByDescending(ordem);
        }

        public T GetById(ID id, params System.Linq.Expressions.Expression<Func<T, object>>[] includeProperties)
        {
            if (includeProperties.Any())
            {
                return List(includeProperties).FirstOrDefault(x => x.Id.ToString() == id.ToString());
            }

            return _context.Set<T>().Find(id);
        }

        public T Add(T entity)
        {
            return _context.Set<T>().Add(entity);
        }

        public T Update(T entity)
        {
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;

            return entity;
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public IEnumerable<T> AddList(IEnumerable<T> entidades)
        {
            return _context.Set<T>().AddRange(entidades);
        }

        private IQueryable<T> Include(IQueryable<T> query, params Expression<Func<T, object>>[] includeProperties)
        {
            foreach (var property in includeProperties)
            {
                query = query.Include(property);
            }

            return query;
        }
    }
}
