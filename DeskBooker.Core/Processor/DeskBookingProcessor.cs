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
            if(deskRepository.GetAvailableDesks(request.Date).Count() > 0)
            {
                deskBookingRepository.Save(Create<DeskBooking>(request));
            }
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