using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solution.Server.Services.BookingServices;
using Solution.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolutionPP.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBooking _repo;

        public BookingController(IBooking repo)
        {
            _repo = repo;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Bookings bookings)
        {
            await _repo.CreateBooking(bookings);

            return Created("", bookings);
        }

        [HttpPost("clientbookings")]
        public async Task<IActionResult> MyBooking(Bookings client)
        {
            var profile = await _repo.FindClient(client);
            var My_Bookings = await _repo.MyBookings(profile.Client.GID);

            return Ok(My_Bookings);
        }

        [HttpGet("booking/{GID}")]
        public async Task<IActionResult> Find(Guid GID)
        {
            var booking = await _repo.FindBooking(GID);

            return Ok(booking);
        }

        [HttpGet]
        public async Task<IActionResult> Booking()
        {
            var booking = await _repo.ListBookings();

            return Ok(booking);
        }

        [HttpPut("{GID}")]
        public async Task<IActionResult> UpdateBooking(Guid GID, Bookings booking)
        {
            if (booking == null)
                return BadRequest();

            var existing = await _repo.FindBooking(GID);
            if (existing == null)
                return NotFound();

            await _repo.UpdateBooking(existing, booking);

            return NoContent();
        }
    }
}
