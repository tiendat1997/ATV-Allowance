using DataService.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        //Add new entity
        void Add(T entity);
        void AddRange(List<T> entities);
        //Modified entity
        void Update(T entity);
        //Remove entity
        void Delete(T entity);
        void DeleteRange(List<T> entities);
        //Remove entity by Expression (id, name)
        void Delete(Expression<Func<T, bool>> where);
        //Get an entity by id
        T GetById(int id);
        //Get an entity using delegate
        IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");
        IEnumerable<T> GetAsNoTracking(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");

        //Gets all entities of type T
        IEnumerable<T> GetAll();
        //Gets entities using delegate
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
        bool Exist(Expression<Func<T, bool>> predicate);
    }

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal ATVEntities context;
        internal DbSet<TEntity> dbSet;

        public Repository()
        {
            this.context = new ATVEntities();
            this.dbSet = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
        }

        public void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            context.SaveChanges();
        }

        public void Delete(Expression<Func<TEntity, bool>> where)
        {
            IQueryable<TEntity> query = dbSet;
            query = query.Where(where);
            TEntity entity = query.FirstOrDefault();
            if (entity != null)
            {
                Delete(entity);
            }
            context.SaveChanges();
        }

        public TEntity GetById(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }

        public IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where)
        {
            return dbSet.Where(where).ToList();
        }

        public bool Exist(Expression<Func<TEntity, bool>> predicate)
        {
            var exist = dbSet.Where(predicate);
            return exist.Any() ? true : false;
        }

        public TEntity Create(TEntity entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public IEnumerable<TEntity> GetAsNoTracking(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet.AsNoTracking();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public void DeleteRange(List<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (context.Entry(entity).State == EntityState.Detached)
                {
                    dbSet.Attach(entity);
                }
                dbSet.Remove(entity);
            }
            context.SaveChanges();
        }

        public void AddRange(List<TEntity> entities)
        {
            dbSet.AddRange(entities);
            context.SaveChanges();
        }
    }
}
