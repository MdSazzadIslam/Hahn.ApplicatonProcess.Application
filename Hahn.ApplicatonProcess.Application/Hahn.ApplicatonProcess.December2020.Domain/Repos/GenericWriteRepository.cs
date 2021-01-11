using Hahn.ApplicatonProcess.December2020.Domain.Context;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.Repos
{
    public class GenericWriteRepository : IGenericWriteRepository
    {
        private readonly ApplicationContext _dbContext;

        public GenericWriteRepository(ApplicationContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public Task<T> AddAsync<T>(T entity) where T : BaseEntity
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteAsync<T>(T entity) where T : BaseEntity
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(DeleteAsync)} entity must not be null");
            }

            try
            {

                _dbContext.Remove(entity);
                return await _dbContext.SaveChangesAsync();


            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be deleted: {ex.Message}");
            }
        }

        public Task<T> InsertAsync<T>(T entity) where T : BaseEntity
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync<T>(IEnumerable<T> entities) where T : BaseEntity
        {
            throw new NotImplementedException();
        }

        public async Task<int> SaveAsyn<T>(T entity) where T : BaseEntity //Modification
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(InsertAsync)} entity must not be null");
            }

            try
            {
                await _dbContext.AddAsync(entity);
                return await _dbContext.SaveChangesAsync();


            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(T)} could not be saved: {ex.Message}");
            }
        }

        public Task<int> SaveAsyn<T>() where T : BaseEntity
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateAsync<T>(T entity) where T : BaseEntity
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(UpdateAsync)} entity must not be null");
            }

            try
            {

                _dbContext.Update(entity);
                return await _dbContext.SaveChangesAsync();


            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }
        public async Task<T> GetByIdAsync<T>(int id) where T : BaseEntity
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }
    }

}
