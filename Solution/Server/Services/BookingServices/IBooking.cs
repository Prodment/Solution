using Solution.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.Server.Services.BookingServices
{
    public interface IBooking
    {
        Task CreateBooking(Bookings booking);
        Task UpdateBooking(Bookings OldBooking,Bookings booking);
        Task CancelBooking(Guid GID);
        Task<Bookings> FindBooking(Guid GID);

        Task<Bookings> FindClient(Bookings bookings);
        Task<List<Bookings>> ListBookings();
        Task<List<Bookings>> MyBookings(Guid GID);
    }
}
