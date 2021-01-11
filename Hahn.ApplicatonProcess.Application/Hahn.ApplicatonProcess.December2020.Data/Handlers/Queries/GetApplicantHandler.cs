using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Data.Handlers.Queries
{
    public class GetApplicantHandler : IRequestHandler<GetApplicant, IEnumerable<Applicant>>
    {
        private readonly IApplicantReadService _applicantReadService;
        public GetApplicantHandler(IApplicantReadService applicantService)
        {
            _applicantReadService = applicantService ?? throw new ArgumentNullException(nameof(applicantService));
        }

        public async Task<IEnumerable<Applicant>> Handle(GetApplicant request, CancellationToken cancellationToken)
        {
            var applicants = await _applicantReadService.GetApplicant();
            return applicants;
        }
    }
}
