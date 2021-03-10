using DeskBooker.Entities;
using System;
using Xunit;

namespace DeskBooker.Core.Tests
{
    public class DeskBookerProcessorTests
    {
        private readonly DeskBookerProcessor processor;
        private readonly DeskBookerRequest request;

        public DeskBookerProcessorTests()
        {
            processor = new DeskBookerProcessor();
            request = new DeskBookerRequest()
            {
                FirstName = "Emem",
                LastName = "Isaac",
                Email = "emem-isaac@someniceplace.com",
                Date = new DateTime(2021, 03, 08)
            };
        }

        [Fact]
        public void ReturnsDeskBookerRequestResult()
        {
            DeskBookerRequestResult result = processor.BookDesk(request);
            Assert.Equal(request.Date, result.Date);
            Assert.Equal(request.Email, result.Email);
            Assert.Equal(request.FirstName, result.FirstName);
            Assert.Equal(request.LastName, result.LastName);
        }

        [Fact]
        public void ThrowsArgumentNullExceptionIfRequestIsNull()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => processor.BookDesk(null));
            Assert.Equal("request", exception.ParamName);
        }
        
    }
}
