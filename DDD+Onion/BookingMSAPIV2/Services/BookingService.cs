using BookingMsApiV2.DTO;
using BookingMsApiV2.Services;
using Infrastructure;

namespace Domain
{
    internal class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public BookingDTO Book(BookingDTO booking)
        {

            var bookingEntity = new BookingEntity(booking.Email, booking.Name, booking.PhoneNumber, booking.Amount, booking.Date);

            if (bookingEntity.IsValid)
            {
                lock (_bookingRepository)
                {
                    var existingBooking = _bookingRepository.GetBooking(bookingEntity.Email, bookingEntity.Date);

                    if (existingBooking == null)
                    {
                        _bookingRepository.AddBooking(bookingEntity);
                    }
                    else
                    {
                        bookingEntity.Errors.Add("There is already a booking for this email on this date");
                    }
                }
            }

            return CastUtil.Cast< BookingEntity, BookingDTO>(bookingEntity);
        }
    }
}
