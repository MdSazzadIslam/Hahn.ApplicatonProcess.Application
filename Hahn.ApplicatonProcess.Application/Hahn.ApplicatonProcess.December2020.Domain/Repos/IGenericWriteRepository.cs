using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.Repos
{
    public interface IGenericWriteRepository
    {
        Task<T> InsertAsync<T>(T entity) where T : BaseEntity;
        Task<T> AddAsync<T>(T entity) where T : BaseEntity;
        Task<int> SaveAsyn<T>() where T : BaseEntity;
        Task<int> SaveAsyn<T>(T entity) where T : BaseEntity; //modificaiton
        Task<int> InsertAsync<T>(IEnumerable<T> entities) where T : BaseEntity;
        Task<int> UpdateAsync<T>(T entity) where T : BaseEntity; //Modificaiton
        Task<int> DeleteAsync<T>(T entity) where T : BaseEntity; //modification
        Task<T> GetByIdAsync<T>(int id) where T : BaseEntity; 



    }
}
