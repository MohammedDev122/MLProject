using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlDAL.Interfaces
{
    public interface IRepository<T>
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
            /// Updates an existing entity in the database.
            /// </summary>
            /// <param name="entity">The entity containing the updated values.</param>
            /// <returns>
            /// A task that represents the asynchronous operation. The task result
            /// indicates whether the update was successful.
            /// </returns>
            public Task<bool> UpdateAsync(T entity);

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

            /// <summary>
            /// Retrieves all entities from the database.
            /// </summary>
            /// <returns>
            /// A task that represents the asynchronous operation. The task result
            /// contains a list of all entities.
            /// </returns>
            public Task<List<T>> GetAllAsync();

            /// <summary>
            /// Determines whether an entity with the specified ID exists in the database.
            /// </summary>
            /// <param name="id">The ID of the entity to check.</param>
            /// <returns>
            /// A task that represents the asynchronous operation. The task result
            /// indicates whether an entity with the specified ID exists.
            /// </returns>
            public Task<bool> ExistsAsync(int id);
    }
}
