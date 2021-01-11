using Hahn.ApplicatonProcess.December2020.Data.Handlers;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using Hahn.ApplicatonProcess.December2020.Domain.Repos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Data.Services
{
    public class ApplicantWriteService : IApplicantWriteService
    {
        private readonly IGenericWriteRepository _genericWriteRepository;
        

        public ApplicantWriteService(IGenericWriteRepository genericWriteRepository)
        {
            this._genericWriteRepository  = genericWriteRepository ?? throw new ArgumentNullException(nameof(genericWriteRepository)); ;
        }

        public async Task<int> CreateApplicant(Applicant applicant)
        {
            return await _genericWriteRepository.SaveAsyn(applicant);

        }
               

        public async  Task<int> DeleteApplicant(int id)
        {

            var data = await _genericWriteRepository.GetByIdAsync<Applicant>(id);
            if (data == null)
            {
                return 0;
            }
            return await _genericWriteRepository.DeleteAsync(data);
        }

       
        public async Task<int> UpdateApplicant(Applicant applicant)
        {
            return await _genericWriteRepository.UpdateAsync(applicant);
        }
    }
}
