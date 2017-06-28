using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HomeInventory.Repository.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : class
    {
        #region Member Variables
        private IDbSet<TEntity> _dbset;
        private DbContext _context;
        #endregion Member Variables

        #region Properties
        /// <summary>
        /// The associated DbContext
        /// </summary>
        public DbContext Context
        {
            get
            {
                return _context;
            }

            set
            {
                _context = value;
            }
        }
        #endregion Properties

        #region Constructor
        public Repository(DbContext context)
        {
            _context = context;
        }
        #endregion Constructor

        #region IRepository<TEntity> implementation
        /// <summary>
        /// The dbset managed by the repository
        /// </summary>
        public IDbSet<TEntity> DbSet
        {
            get
            {
                if (_dbset == null)
                {
                    _dbset = _context.Set<TEntity>();
                }

                return _dbset;
            }
        }

        /// <summary>
        /// The dbquery managed by the repository
        /// </summary>
        public virtual DbQuery<TEntity> DbQuery
        {
            get { return (DbQuery<TEntity>)DbSet; }
        }

        /// <summary>
        /// Returns the entire entity collection for further querying
        /// </summary>
        public virtual IQueryable<TEntity> All
        {
            get { return DbSet.AsQueryable(); }
        }

        /// <summary>
        /// Returns the entire entity collection with the specified tables included
        /// </summary>
        /// <param name="includeTables"></param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> AllWithAssociations(params string[] includeTables)
        {
            var query = DbQuery;

            foreach (var nav in includeTables)
            {
                query = query.Include(nav);
            }

            return query.AsQueryable();
        }

        /// <summary>
        /// Adds an entity to the repository
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        /// <summary>
        /// Deletes an entity from the repository
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(TEntity entity)
        {
            Attach(entity);
            DbSet.Remove(entity);
        }

        /// <summary>
        /// Attaches the entity to the repository and marks it modified
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Edit(TEntity entity)
        {
            Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Saves any changes made to entities in the repository
        /// </summary>
        public virtual void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Debug.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                            ve.PropertyName,
                            eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                            ve.ErrorMessage);
                    }
                }
                throw;
            }

        }
        #endregion IRepository<TEntity> implementation

        #region IDisposable implementation
        public void Dispose()
        {
            ((IDisposable)_context).Dispose();
        }
        #endregion IDisposable implementation
        
        #region Private Methods
        /// <summary>
        /// Attaches an entity to the repository if it is not already attached.
        /// </summary>
        /// <param name="entity"></param>
        private void Attach(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _context.Set<TEntity>().Attach(entity);
            }
        }
        #endregion Private Methods
    }
}

