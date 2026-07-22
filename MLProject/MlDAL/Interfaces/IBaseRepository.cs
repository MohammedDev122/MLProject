using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlDAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        /// <summary>
        /// Adds a new entity to the database.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result
        /// contains the ID of the newly created entity.
        /// </returns>
        public Task<int> AddAsync(T entity);

        /// <summary>
        /// Deletes the entity with the specified ID from the database.
        /// </summary>
        /// <param name="id">The ID of the entity to delete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result
        /// indicates whether the deletion was successful.
        /// </returns>
        public Task<bool> DeleteAsync(int id);

        /// <summary>
        /// Retrieves an entity with the specified ID from the database.
        /// </summary>
        /// <param name="id">The ID of the entity to retrieve.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result
        /// contains the entity if found; otherwise, <see langword="null"/>.
        /// </returns>
        public Task<T?> GetByIdAsync(int id);

    }

    public interface IGetAll<T>
    {
        /// <summary>
        /// Retrieves all entities from the database.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result
        /// contains a list of all entities.
        /// </returns>
        public Task<List<T>> GetAllAsync();
    }

    public interface IUpdate<T>
    {
        /// <summary>
        /// Updates an existing entity in the database.
        /// </summary>
        /// <param name="entity">The entity containing the updated values.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result
        /// indicates whether the update was successful.
        /// </returns>
        public Task<bool> UpdateAsync(T entity);
    }

    public interface ISearch<T>
    {
        /// <summary>
        /// Retrieves all entities whose searchable field matches the specified key.
        /// </summary>
        /// <param name="key">The search keyword used to find matching entities.</param>
        /// <returns>
        /// A list of all entities that match the specified search key.
        /// Returns an empty list if no matching entities are found.
        /// </returns>
        public Task<List<T>> GetByKey (string key);
    }

    public interface IExists<T>
    {

        /// <summary>
        /// Determines whether an entity with the specified ID exists in the database.
        /// </summary>
        /// <param name="id">The ID of the entity to check.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result
        /// indicates whether an entity with the specified ID exists.
        /// </returns>
        public Task<bool> ExistsAsync(int id);

        /// <summary>
        /// Checks whether an entity with the specified unique name exists.
        /// </summary>
        /// <param name="name">The unique name to search for.</param>
        /// <returns>
        /// <c>true</c> if an entity with the specified name exists; otherwise, <c>false</c>.
        /// </returns>
        public Task<bool> ExistsAsync(string name);

    }

}
