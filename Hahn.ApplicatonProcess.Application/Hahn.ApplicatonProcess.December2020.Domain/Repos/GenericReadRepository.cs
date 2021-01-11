using Hahn.ApplicatonProcess.December2020.Domain.Context;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.Repos
{
    public class GenericReadRepository : IGenericReadRepository
    {
        private readonly ApplicationContext _dbContext;

        public GenericReadRepository(ApplicationContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<bool> IfExistsAsync<T>(ISpecification<T> spec = null) where T : BaseEntity
        {
            return await ApplySpecification(spec).AnyAsync();
        }
        public async Task<int> CountAsync<T>(ISpecification<T> spec = null) where T : BaseEntity
        {
            return await ApplySpecification(spec).CountAsync<T>();
        }

        private IQueryable<T> ApplySpecification<T>(ISpecification<T> spec) where T : BaseEntity
        {
            return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
        }

        public IQueryable<T> GetAll<T>(ISpecification<T> spec = null) where T : BaseEntity
        {
            return ApplySpecification(spec).AsNoTracking();
        }

        public async Task<T> GetByIdAsync<T>(Guid id) where T : BaseEntity
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync<T>() where T : BaseEntity
        {
            return await _dbContext.Set<T>().OrderByDescending(x=>x.Id).ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListByIdAsync<T>(int id) where T : BaseEntity
        {
            return await _dbContext.Set<T>().Where(x=>x.Id == id).OrderByDescending(x => x.Id).ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync<T>(ISpecification<T> spec = null) where T : BaseEntity
        {
            return await GetAll(spec).OrderByDescending(x => x.Id).ToListAsync();
        }

        public async Task<T> GetAsync<T>(ISpecification<T> spec = null) where T : BaseEntity
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }
    }
}
