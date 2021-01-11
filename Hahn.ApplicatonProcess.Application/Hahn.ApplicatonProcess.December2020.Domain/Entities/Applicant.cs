 using System;


namespace Hahn.ApplicatonProcess.December2020.Domain.Entities
{
    
    public class Applicant  : BaseEntity
    {
        
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string Address { get; set; }
        public string CountryOfOrigin { get; set; }
        public string EmailAdress { get; set; }
        public int Age { get; set; }
        public bool Hired { get; set; }




    }



}
