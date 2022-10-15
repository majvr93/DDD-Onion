using BookingMsApiV2.DTO;

namespace Domain
{
    public interface IBookingService
    {
        BookingDTO Book(BookingDTO booking);
    }
}