using Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure
{
    internal class BookingRepository : IBookingRepository
    {
        private List<BookingEntity> _storage;

        public BookingRepository()
        {
            _storage = new List<BookingEntity>();
        }

        public BookingEntity GetBooking(string email, DateTime date)
        { 
           var  booking = _storage.Where(s => s.Email == email && s.Date.Date == date.Date).FirstOrDefault();
            return booking;
        }

        public void AddBooking(BookingEntity booking)
        {
            _storage.Add(booking);
        }
    }
}
