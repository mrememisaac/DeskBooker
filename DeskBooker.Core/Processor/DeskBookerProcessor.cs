using DeskBooker.Entities;
using System;

namespace DeskBooker.Core
{
    public class DeskBookerProcessor
    {
        public DeskBookerProcessor()
        {
        }

        public DeskBookerRequestResult BookDesk(DeskBookerRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            return new DeskBookerRequestResult()
            {
                Email = request.Email,
                LastName = request.LastName,
                FirstName = request.FirstName,
                Date = request.Date
            };
        }
    }
}