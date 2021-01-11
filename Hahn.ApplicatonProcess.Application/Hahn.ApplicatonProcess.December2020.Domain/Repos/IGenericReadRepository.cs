using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.Repos
{
    public interface IGenericReadRepository
    {
        Task<T> GetByIdAsync<T>(Guid id) where T : BaseEntity;
        Task<T> GetAsync<T>(ISpecification<T> spec = null) where T : BaseEntity;
        IQueryable<T> GetAll<T>(ISpecification<T> spec = null) where T : BaseEntity;
        Task<int> CountAsync<T>(ISpecification<T> spec = null) where T : BaseEntity;
        Task<bool> IfExistsAsync<T>(ISpecification<T> spec = null) where T : BaseEntity;
        Task<IReadOnlyList<T>> ListAsync<T>(ISpecification<T> spec = null) where T : BaseEntity;
        Task<IReadOnlyList<T>> ListByIdAsync<T>(int id) where T : BaseEntity;
 
    }
}
