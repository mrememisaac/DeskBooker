using DeskBooker.Entities;

namespace DeskBooker.Data
{
    public interface IDeskBookingRepository
    {
        void Save(DeskBooking deskBooking);
    }
}