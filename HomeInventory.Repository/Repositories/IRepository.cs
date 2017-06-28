using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeInventory.Repository.Repositories
{
    public interface IRepository : IDisposable
    {
        /// <summary>
        /// The repository's context
        /// </summary>
        DbContext Context { get; set; }
    }

    public interface IRepository<TEntity> : IRepository where TEntity : class
    {
        /// <summary>
        /// The dbset managed by the repository
        /// </summary>
        IDbSet<TEntity> DbSet { get; }

        /// <summary>
        /// The dbquery managed by the repository
        /// </summary>
        DbQuery<TEntity> DbQuery { get; }

        /// <summary>
        /// Returns the entire entity collection for further querying
        /// </summary>
        IQueryable<TEntity> All { get; }

        /// <summary>
        /// Returns the entire entity collection for further querying and includes tables included in the includeTables parameter
        /// </summary>
        /// <param name="includeTables"></param>
        IQueryable<TEntity> AllWithAssociations(params string[] includeTables);

        /// <summary>
        /// Adds an entity to the repository
        /// </summary>
        /// <param name="entity"></param>
        void Add(TEntity entity);

        /// <summary>
        /// Deletes an entity from the repository
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);

        /// <summary>
        /// Attaches the entity to the repository and marks it modified
        /// </summary>
        /// <param name="entity"></param>
        void Edit(TEntity entity);

        /// <summary>
        /// Saves any changes made to entities in the repository
        /// </summary>
        void Save();
    }
}

