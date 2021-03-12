using System;
using System.Collections.Generic;

namespace DeskBooker.Entities
{
    public class BookDeskRequestResult : DeskBookingBase
    {
        public DeskBookingResultCode ResultCode { get; set; }
    }
}