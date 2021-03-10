using System;
using System.Linq;

namespace DeskBooker.Data
{
    public interface IDeskRepository
    {
        IQueryable<Desk> GetAvailableDesks(DateTime date);
    }
}
