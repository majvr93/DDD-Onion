using BookingMsApiV2.DTO;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingMSAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    { 

        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        //{ 
        //  "email": "jose.martins@quest-soft.com",
        //  "phoneNumber": "123",
        //  "name": "123",
        //  "amount": 10,
        //  "date": "2022-01-21T18:31:50.621Z",
        //  "errors": [],
        //  "isValid": true
        //}

    [HttpPost]
        [AllowAnonymous]
        public IActionResult Book([FromBody]BookingDTO booking)
        {
            var newBooking = _bookingService.Book(booking);

            if (newBooking.IsValid)
            {
                return Ok();
            }
            else
            {
                return BadRequest(newBooking);
            }
        }
    }
}
