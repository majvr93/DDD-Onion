using System;
using System.Collections.Generic;

namespace BookingMsApiV2.DTO
{
    public class BookingDTO
    {
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Name { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public List<string> Errors { get; set; }

        public bool IsValid { get; set; }

        public BookingDTO()
        {
            Errors = new List<string>();
        }
    }
}
