using MlBL.DTOs;

namespace MlBL.Interfaces
{
    public interface IAnalysisService
    {
        /// <summary>
        /// Adds a new entity to the system.
        /// </summary>
        /// <param name="entity">The DTO to add.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result
        /// contains the newly created analysis.
        /// null means creation failed
        /// </returns>
        public Task<AnalysisDto> AddAsync(CreateAnalysisDto newAnalysis);

        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        /// <param name="entity">The DTO containing the updated values.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result
        /// indicates whether the update was successful.
        /// null means update fails
        /// </returns>
        public Task<bool> UpdateAsync(UpdateAnalysisDto analysis);

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
        public Task<AnalysisDto?> GetByIdAsync(int id);

        /// <summary>
        /// Retrieves all entities.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result
        /// contains a list of all DTOs.
        /// </returns>
        public Task<List<AnalysisDto>> GetAllAsync();

    }
}
