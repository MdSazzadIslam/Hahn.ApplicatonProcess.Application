using Hahn.ApplicatonProcess.December2020.Data.Common.Interfaces;
using Hahn.ApplicatonProcess.December2020.Data.Common.Messages;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Data.Handlers.Commands
{
    public class CreateApplicantHandler : IRequestHandler<CreateApplicant, int>
    {
        private readonly IApplicantWriteService _applicantWriteService;
        private readonly IDateTime _dateTime;

        public CreateApplicantHandler(IApplicantWriteService applicantService, IDateTime dateTime)
        {
            _applicantWriteService = applicantService ?? throw new ArgumentNullException(nameof(applicantService));
            _dateTime = dateTime ?? throw new ArgumentNullException(nameof(dateTime));

        }
        public async Task<int> Handle(CreateApplicant request, CancellationToken cancellationToken)
        {
            var applicant = new Domain.Entities.Applicant
            {
                Id =  request.Id,
                Name = request.Name,
                FamilyName = request.FamilyName,
                Address = request.Address,
                CountryOfOrigin = request.CountryOfOrigin,
                EmailAdress = request.EmailAdress,
                Age = request.Age,
                Hired = request.Hired ? true : false,
               

            };

            int result =  await _applicantWriteService.CreateApplicant(applicant);
            return result;

        }
    } 

}
