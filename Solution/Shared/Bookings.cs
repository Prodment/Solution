using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Shared
{
    public class Bookings
    {
        [Key]
        public Guid GID { get; set; }
        public DateTime BookingTime { get; set; }
        public DateTime BookingDate { get; set; }
        public string Venue { get; set; }
        public string RefNo { get; set; }
        public string EventName { get; set; }
        public string VenueAddress { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public bool Deposit { get; set; }
        public bool Paid { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public Client Client { get; set; }
    }

    public class Client
    {
        [Key]
        public Guid GID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
    }
}
