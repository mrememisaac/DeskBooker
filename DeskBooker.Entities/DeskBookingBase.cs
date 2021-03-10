﻿using System;

namespace DeskBooker.Entities
{
    public class DeskBookingBase : IDeskBooking
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
    }
}