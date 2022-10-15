using System;

namespace BookingMsApiV2.Domain.Validators
{
    public static class DateValidator
    {
        public static string ValidateNotInPast(DateTime date)
        {
            if (date == null)
            {
                return "Invalid date";
            }

            if (date.Date < DateTime.UtcNow.Date)
            {
                return "Past date";
            }

            return null;
        }
    }
}