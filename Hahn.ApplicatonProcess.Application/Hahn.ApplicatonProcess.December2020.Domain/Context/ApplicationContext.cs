using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Hahn.ApplicatonProcess.December2020.Domain.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        public ApplicationContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            { 


            }
        }
        public virtual DbSet<Applicant> Applicant { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Applicant>().HasData(
                    new Applicant
                    {
                        Id = 2,
                        Name = "Md Sazzadul Islam",
                        FamilyName = "Sopon",
                        Address = "House No# 8, Road No# 4/3, Block B, Section #12, Mirpur Pallabi, Dhaka, Bangladesh.",
                        CountryOfOrigin = "Bangladesh",
                        EmailAdress = "netsazzad@gmail.com",
                        Age = 31,
                        Hired = true


                    },
                    new Applicant
                    {
                        Id = 3,
                        Name = "Md Shakheul Islam",
                        FamilyName = "Sagor",
                        Address = "House No# 8, Road No# 4/3, Block B, Section #12, Mirpur Pallabi, Dhaka, Bangladesh.",
                        CountryOfOrigin = "Bangladesh",
                        EmailAdress = "netsazzad@gmail.com",
                        Age = 26,
                        Hired = true
                    },
                      new Applicant
                      {
                          Id = 4,
                          Name = "Md Shafiul Islam",
                          FamilyName = "Sumon",
                          Address = "House No# 8, Road No# 4/3, Block B, Section #12, Mirpur Pallabi, Dhaka, Bangladesh.",
                          CountryOfOrigin = "Bangladesh",
                          EmailAdress = "netsazzad@gmail.com",
                          Age = 26,
                          Hired = true
                      });


        }


    }

}
