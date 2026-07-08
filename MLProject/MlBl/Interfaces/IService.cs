using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlBL.Interfaces
{
     /// <summary>
     /// Defines a generic service that provides common business operations
     /// for a specific DTO type.
     /// </summary>
     /// <typeparam name="T">The DTO type managed by the service.</typeparam>
    public interface IService<T>
    {
        /// <summary>
        /// Adds a new entity to the system.
        /// </summary>
        /// <param name="entity">The DTO to add.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result
        /// contains the ID of the newly created entity.
        /// </returns>
        public Task<int> AddAsync(T entity);

        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        /// <param name="entity">The DTO containing the updated values.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result
        /// indicates whether the update was successful.
        /// </returns>
        public Task<bool> UpdateAsync(T entity);

        /// <summary>
        /// Deletes the entity with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the entity to delete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result
        /// indicates whether the deletion was successful.
        /// </returns>
        public Task<bool> DeleteAsync(int id);

        /// <summary>
        /// Retrieves the entity with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the entity to retrieve.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result
        /// contains the requested DTO if found; otherwise, <see langword="null"/>.
        /// </returns>
        public Task<T?> GetByIdAsync(int id);

        /// <summary>
        /// Retrieves all entities.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result
        /// contains a list of all DTOs.
        /// </returns>
        public Task<List<T>> GetAllAsync();

        /// <summary>
        /// Determines whether an entity with the specified ID exists.
        /// </summary>
        /// <param name="id">The ID of the entity to check.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result
        /// indicates whether the entity exists.
        /// </returns>
        public Task<bool> ExistsAsync(int id);
    
    }
}
