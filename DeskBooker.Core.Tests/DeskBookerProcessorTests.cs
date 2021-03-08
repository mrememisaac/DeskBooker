using DeskBooker.Entities;
using System;
using Xunit;

namespace DeskBooker.Core.Tests
{
    public class DeskBookerProcessorTests
    {
        [Fact]
        public void ReturnsDeskBookerRequestResult()
        {
            var processor = new DeskBookerProcessor();
            var request = new DeskBookerRequest()
            {
                FirstName = "Emem",
                LastName = "Isaac",
                Email = "emem-isaac@someniceplace.com",
                Date = new DateTime(2021, 03, 08)
            };
            DeskBookerRequestResult result = processor.BookDesk(request);
            Assert.Equal(request.Date, result.Date);
            Assert.Equal(request.Email, result.Email);
            Assert.Equal(request.FirstName, result.FirstName);
            Assert.Equal(request.LastName, result.LastName);
        }

    }
}
