using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Data.Handlers.Queries
{
    public class GetApplicant : IRequest<IEnumerable<Applicant>>
    {
        
    }
}
