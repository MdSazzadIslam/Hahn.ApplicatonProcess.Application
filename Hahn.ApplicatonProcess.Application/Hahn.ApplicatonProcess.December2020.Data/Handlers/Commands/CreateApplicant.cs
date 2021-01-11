using Hahn.ApplicatonProcess.December2020.Data.Common.Messages;
using MediatR;


namespace Hahn.ApplicatonProcess.December2020.Data.Handlers.Commands
{
    public class CreateApplicant : IRequest<int>
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string Address { get; set; }
        public string CountryOfOrigin { get; set; }
        public string EmailAdress { get; set; }
        public int Age { get; set; }
        public bool Hired { get; set; }


    }
}
