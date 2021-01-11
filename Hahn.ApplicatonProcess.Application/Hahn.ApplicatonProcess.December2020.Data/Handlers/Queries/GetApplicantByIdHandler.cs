using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Data.Handlers.Queries
{
    public class GetApplicantByIdHandler : IRequestHandler<GetApplicantById, IEnumerable<Applicant>>
    {
        private readonly IApplicantReadService _applicantReadService;
        public GetApplicantByIdHandler(IApplicantReadService applicantService)
        {
            _applicantReadService = applicantService ?? throw new ArgumentNullException(nameof(applicantService));
        }

        public async Task<IEnumerable<Applicant>> Handle(GetApplicantById request, CancellationToken cancellationToken)
        {
            var applicants = await _applicantReadService.GetApplicantById(request.Id);
            return applicants;
        }
    }
}
