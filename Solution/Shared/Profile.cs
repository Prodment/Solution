using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Shared
{
    public class Profile
    {
        [Key]
        public Guid GID { get; set; }
        public string KnownAs { get; set; }
        public string Contact { get; set; }
        public string Biography { get; set; }
        public string CountryOfBirth { get; set; }
        public string Nationality { get; set; }
        public string Gender { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public BankDetails BankDetails { get; set; }
        public Address Address { get; set; }
               
    }

    public class Address
    {
        [Key]
        public Guid GID { get; set; }
        public string City { get; set; }
        public string Surburb { get; set; }
        public string ResidentialAddress { get; set; }
        public string PostalAddress { get; set; }
    }

    public class BankDetails
    {
        [Key]
        public Guid GID { get; set; }
        public string BankName { get; set; }
        public string AccountHolder { get; set; }
        public string AccountType { get; set; }
        public string BranchName { get; set; }
        public string BranchCode { get; set; }
    }
}
