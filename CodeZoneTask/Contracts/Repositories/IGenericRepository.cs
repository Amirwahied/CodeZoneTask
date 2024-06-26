﻿using CodeZoneTask.Models.Entities;

namespace CodeZoneTask.Contracts.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        //return immutable list
        Task<IReadOnlyList<T>> GetAsync();
        //return single record with id
        Task<T?> GetByIdAsync(int id);
        //create new record
        Task CreateAsync(T entity);
        //update  record
        Task UpdateAsync(T entity);
        //delete record
        Task DeleteAsync(T entity);

    }
}
