using DeskBooker.Data;
using DeskBooker.Entities;
using System;
using System.Linq;

namespace DeskBooker.Core
{
    public class DeskBookingProcessor
    {
        private readonly IDeskBookingRepository deskBookingRepository;
        private readonly IDeskRepository deskRepository;

        public DeskBookingProcessor()
        {
        }

        public DeskBookingProcessor(IDeskBookingRepository deskBookingRepository, IDeskRepository deskRepository)
        {
            this.deskBookingRepository = deskBookingRepository;
            this.deskRepository = deskRepository;
        }

        public BookDeskRequestResult BookDesk(BookDeskRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            var resultCode = DeskBookingResultCode.NoDeskAvailable;
            if (deskRepository.GetAvailableDesks(request.Date).FirstOrDefault() is Desk desk)
            {
                var booking = Create<DeskBooking>(request);
                booking.DeskId = desk.Id;
                deskBookingRepository.Save(booking);
                resultCode = DeskBookingResultCode.Success;
            }
            var result = Create<BookDeskRequestResult>(request);
            result.ResultCode = resultCode;
            return result;
        }

        private static T Create<T>(BookDeskRequest request) where T : DeskBookingBase, new()
        {
            return new T
            {
                Date = request.Date,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName                
            };
        }
    }
}