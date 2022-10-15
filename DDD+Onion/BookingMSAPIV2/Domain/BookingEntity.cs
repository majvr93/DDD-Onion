using BookingMsApiV2.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    internal class BookingEntity
    {
        private const int StringLength = 50;

        public Guid UniqueId { get; protected set; }

        public string Email { get; protected set; }

        public string PhoneNumber { get; protected set; }

        public string Name { get; protected set; }

        public decimal Amount { get; protected set; }

        public DateTime Date { get; protected set; }

        public List<string> Errors { get; protected set; }

        public bool IsValid => !Errors.Any();
         
        public BookingEntity(string email, string name, string phoneNumber, decimal amount, DateTime date)
        {
            Errors = new List<string>();
            UniqueId = Guid.NewGuid();
            SetEmail(email);
            SetName(name);
            SetPhoneNumber(phoneNumber);
            SetAmount(amount);
            SetDate(date);
        }

        public void SetDate(DateTime date)
        {
            var error = DateValidator.ValidateNotInPast(date);
            if (error != null)
            {
                Errors.Add(error);
            }

            Date = date;
        }

        public void SetEmail(string email)
        {
            ValidateEmail(email);
            Email = email;
        }

        public void SetName(string name)
        {
            ValidateIsNullOrWhiteSpace(name, "name");
            ValidateLength(name, "name");
            Name = name;
        }

        public void SetAmount(decimal amount)
        {
            Amount = amount;
        }

        public void SetPhoneNumber(string phoneNumber)
        {
            ValidateIsNullOrWhiteSpace(phoneNumber, "phoneNumber");
            ValidateLength(phoneNumber, "phoneNumber");
            PhoneNumber = phoneNumber;
        }

        private void ValidateEmail(string email)
        {
            var error = EmailValidatior.Validate(email);
            if (error != null)
            {
                Errors.Add(error);
            }

            ValidateLength(email, "email");
        }

        private void ValidateLength(string value, string property)
        {
            var error = StringValidatior.ValidateLength(value, property, StringLength);
            if (error != null)
            {
                Errors.Add(error);
            }
        }

        private void ValidateIsNullOrWhiteSpace(string value, string property)
        {
            var error = StringValidatior.ValidateIsNullOrWhiteSpace(value, property);
            if (error != null)
            {
                Errors.Add(error);
            }
        }
    }
}
