using Hahn.ApplicatonProcess.December2020.Data.Common.Mappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicatonProcess.December2020.Data.Handlers
{
    public class ApplicantVm : IMapFrom<Domain.Entities.Applicant>
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
