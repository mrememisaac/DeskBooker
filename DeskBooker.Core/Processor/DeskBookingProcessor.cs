using DeskBooker.Data;
using DeskBooker.Entities;
using System;

namespace DeskBooker.Core
{
    public class DeskBookingProcessor
    {
        private readonly IDeskBookingRepository deskBookingRepository;

        public DeskBookingProcessor()
        {
        }

        public DeskBookingProcessor(IDeskBookingRepository deskBookingRepository)
        {
            this.deskBookingRepository = deskBookingRepository;
        }

        public BookDeskRequestResult BookDesk(BookDeskRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            deskBookingRepository.Save(Create<DeskBooking>(request));
            return Create<BookDeskRequestResult>(request);
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