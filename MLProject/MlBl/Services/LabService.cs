using Core.Models;
using FluentValidation.Resources;
using MlBL.DTOs;
using MlBL.Interfaces;
using MlBL.Mappers;
using MlDAL.Interfaces;
using MlDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlBL.Services
{
    public class LabService : ILabService
    {
        private readonly ILabRepo _repo;

        public LabService (ILabRepo repo)
        {
            _repo = repo;
        }


        public async Task<LabDto?> AddAsync(LabDto newRecord)
        {
            ArgumentNullException.ThrowIfNull(newRecord);

            var lab = newRecord.ToEntity();

            newRecord.Id = await _repo.AddAsync(lab);

            return (newRecord.Id != 0) ? newRecord : null; 
        }

        public async Task<bool> UpdateAsync(LabDto updatedRecord)
        {
            ArgumentNullException.ThrowIfNull(updatedRecord);
            ArgumentNullException.ThrowIfNull(updatedRecord.Id);

            if(updatedRecord.Id is null)
                throw new ArgumentNullException("Id is required");

            var lab = await _repo.GetByIdAsync(updatedRecord.Id.Value);

            if (lab == null) 
                return false;

            lab.Name = updatedRecord.Name;
            lab.Address = updatedRecord.Address;
            lab.RegionId = updatedRecord.RegionId;
            lab.Status = updatedRecord.Status;

            return await _repo.UpdateAsync(lab);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id, "Analysis ID must be greater than zero.");

            return await _repo.DeleteAsync(id);
        }
        public async Task<LabDto?> GetByIdAsync(int id)
        { 
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id, "Analysis ID must be greater than zero.");

            var lab = await _repo.GetByIdAsync(id);

            return (lab != null) ? lab.ToDto() : null;
        }
        public async Task<List<LabDto>?> GetAllAsync()
        {
            var labs = await _repo.GetAllAsync();

            return (labs != null) ? 

                labs .Select (l => l.ToDto())  
                    .ToList() : null;

        }

    }
}
