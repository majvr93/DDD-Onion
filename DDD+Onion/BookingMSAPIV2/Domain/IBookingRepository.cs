using Domain;
using System;

namespace Infrastructure
{
    internal interface IBookingRepository
    {
        void AddBooking(BookingEntity booking);
        BookingEntity GetBooking(string email, DateTime date);
    }
}