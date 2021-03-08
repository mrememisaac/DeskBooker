using System;

namespace DeskBooker.Entities
{
    public  class DeskBookerRequest
    {
        public DeskBookerRequest()
        {
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
    }
}