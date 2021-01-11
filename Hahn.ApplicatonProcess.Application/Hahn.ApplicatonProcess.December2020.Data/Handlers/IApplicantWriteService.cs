using Hahn.ApplicatonProcess.December2020.Data.Common.Messages;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Data.Handlers
{
    public interface IApplicantWriteService
    {
        public Task<int> CreateApplicant(Applicant applicant);
        public Task<int> UpdateApplicant(Applicant applicant);
        public Task<int> DeleteApplicant(int id);

    }
}
