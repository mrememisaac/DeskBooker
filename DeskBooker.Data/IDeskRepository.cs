using System;
using System.Collections.Generic;

namespace DeskBooker.Data
{
    public interface IDeskRepository
    {
        public IEnumerable<Desk> GetAvailableDesks(DateTime date);
    }
}
