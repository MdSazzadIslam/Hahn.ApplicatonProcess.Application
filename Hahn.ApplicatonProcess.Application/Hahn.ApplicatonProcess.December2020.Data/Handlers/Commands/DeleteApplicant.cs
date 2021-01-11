using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Data.Handlers.Commands
{
    public class DeleteApplicant : IRequest<int>
    {
        public int Id { get; set; }
       
       
    }

}
