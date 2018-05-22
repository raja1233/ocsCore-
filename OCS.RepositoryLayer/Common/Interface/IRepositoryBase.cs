﻿using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace OCS.RepositoryLayer.Common.Interface
{
    public interface IRepositoryBase<T> : IDisposable where T : class
    {
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);

        /// <summary>
        /// Gets the first entity found or default value.
        /// </summary>
        /// <param name="filter">Filter expression for filtering the entities.</param>
        /// <param name="include">Include for eager-loading.</param>
        /// <returns></returns>
        T GetFirstOrDefault(Expression<Func<T, bool>> filter,
                                          params Expression<Func<T, object>>[] include);
        /// <summary>
        /// Creates the specified entity/entities.
        /// </summary>
        /// <param name="entity">Single entity.</param>
        /// <param name="entities">Multiple entities.</param>
        void Create(T entity, params T[] entities);



        /// <summary>
        /// Creates the specified entity/entities.
        /// </summary>
        /// <param name="entities">Multiple entities.</param>
        void Create(T[] entities);

        /// <summary>
        /// Updates the specified entity/entities.
        /// </summary>
        /// <param name="entity">Single entity.</param>
        /// <param name="entities">Multiple entities.</param>
        void Update(T entity, params T[] entities);


        /// <summary>
        /// Updates the specified entity/entities.
        /// </summary>
        /// <param name="entities">Multiple entities.</param>
        void Update(T[] entities);
        /// <summary>
        /// Deletes the specified entity/entities.
        /// </summary>
        /// <param name="entity">Single entity.</param>
        /// <param name="entities">Multiple entities.</param>
        void Delete(T entity, params T[] entities);
        /// <summary>
        /// Deletes the entity by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void Delete(object id);
        /// <summary>
        /// Deletes multiple entities which are found using filter.
        /// </summary>
        /// <param name="filter">Filter expression for filtering the entities.</param>
        void Delete(Expression<Func<T, bool>> filter);
        void Edit(T oldEntity, T newEntity);
        /// <summary>
        /// Saves the changes to the database.
        /// </summary>
        /// <returns>Number of rows affected.</returns>
        int SaveChanges();
        /// <summary>
        /// Fetch all records.
        /// </summary>
        /// <returns></returns>
        /// 
        IQueryable<T> FetchAll();
        /// <summary>
        /// Get all records.
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> exp);
        /// <summary>
        /// Get single record.
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        T Get(Expression<Func<T, bool>> exp);
        /// <summary>
        /// Gets the entity by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        T GetByID(object id);

        IDbContextTransaction RollBackTransactionOnFail();


    }
}