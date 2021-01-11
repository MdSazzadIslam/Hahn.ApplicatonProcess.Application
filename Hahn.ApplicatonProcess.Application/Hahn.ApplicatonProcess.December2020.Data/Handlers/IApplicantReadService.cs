using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Data.Handlers
{
    public interface IApplicantReadService
    {
        public Task<IEnumerable<Applicant>> GetApplicant();
        public Task<IEnumerable<Applicant>> GetApplicantById(int id);


    }
}
