using Microsoft.EntityFrameworkCore;
using Solution.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.Server.Services.BookingServices
{
    public class BookingRepo : IBooking
    {
        private readonly ApplicationContextDb _context;

        public BookingRepo (ApplicationContextDb context)
        {
            _context = context;
        }
        public async Task CancelBooking(Guid GID)
        {

            var booking = await _context.Booking.Include(a => a.Client).FirstOrDefaultAsync(a => a.GID.Equals(GID));

            _context.Remove(booking);

            await _context.SaveChangesAsync();
        }

        public async Task CreateBooking(Bookings booking)
        {
            string RefNo = "";
            Random random = new Random();
            do
            {
                RefNo = "ref" + random.Next(100000, 999999).ToString();

            } while (await _context.Booking.FirstOrDefaultAsync(a => a.RefNo.Equals(RefNo)) != null);

            booking.RefNo = RefNo;
            booking.Created = DateTime.Now;
            _context.Add(booking);
            await _context.SaveChangesAsync();
        }

        public async Task<Bookings> FindBooking(Guid GID) => await _context.Booking.Include(a => a.Client).FirstOrDefaultAsync(a => a.GID.Equals(GID));

        public async Task<Bookings> FindClient(Bookings bookings) => await _context.Booking.Include(a => a.Client).FirstOrDefaultAsync(a => a.Client.Email.Equals(bookings.Client.Email));
       
        public async Task<List<Bookings>> ListBookings() => await _context.Booking.ToListAsync();
        

        public async Task<List<Bookings>> MyBookings(Guid GID) => await _context.Booking.Where(a => a.Client.GID.Equals(GID)).ToListAsync();
        

        public async Task UpdateBooking(Bookings OldBooking, Bookings booking)
        {
            OldBooking = booking;
            OldBooking.Updated = DateTime.Now;
            await _context.SaveChangesAsync();

        }
    }
}
