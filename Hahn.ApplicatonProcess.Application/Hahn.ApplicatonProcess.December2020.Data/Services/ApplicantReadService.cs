using Hahn.ApplicatonProcess.December2020.Data.Handlers;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using Hahn.ApplicatonProcess.December2020.Domain.Repos;
using Hahn.ApplicatonProcess.December2020.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Data.Services
{
    public class ApplicantReadService : IApplicantReadService
    {
        private readonly IGenericReadRepository _genericReadRepository;
        public ApplicantReadService(IGenericReadRepository genericReadRepository)
        {
            this._genericReadRepository = genericReadRepository ?? throw new ArgumentNullException(nameof(genericReadRepository)); ;
        }
 
        public async Task<IEnumerable<Applicant>> GetApplicant()
        {
            var spec = new ApplicantSpecification();
            return await _genericReadRepository.ListAsync(spec);
        }

        public async Task<IEnumerable<Applicant>> GetApplicantById(int id)
        {
            return await _genericReadRepository.ListByIdAsync<Applicant>(id);

        }
 
    }
}
