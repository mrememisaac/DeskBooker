using System;

namespace DeskBooker.Entities
{
    public interface IDeskBooking
    {
        DateTime Date { get; set; }
        string Email { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}