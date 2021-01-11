using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Data.Handlers.Commands
{
    public class DeleteApplicantHandler : IRequestHandler<DeleteApplicant, int>
    {
        private readonly IApplicantWriteService _applicantWriteService;

        public DeleteApplicantHandler(IApplicantWriteService applicantService)
        {
            _applicantWriteService = applicantService ?? throw new ArgumentNullException(nameof(applicantService));
        }

        public async Task<int> Handle(DeleteApplicant request, CancellationToken cancellationToken)
        {

            return await _applicantWriteService.DeleteApplicant(request.Id);

        }
    }
}
