using DeskBooker.Data;
using DeskBooker.Entities;
using System;
using Xunit;
using Moq;
using System.Linq;
using System.Collections.Generic;

namespace DeskBooker.Core.Tests
{
    public class DeskBookingProcessorTests
    {
        private readonly Mock<IDeskBookingRepository> mockDeskBookingRepository;
        private readonly Mock<IDeskRepository> mockDeskRepository;
        private readonly DeskBookingProcessor processor;
        private readonly BookDeskRequest request;
        private readonly List<Desk> availableDesks;

        public DeskBookingProcessorTests()
        {
            mockDeskBookingRepository = new Mock<IDeskBookingRepository>();
            mockDeskRepository = new Mock<IDeskRepository>();
            processor = new DeskBookingProcessor(mockDeskBookingRepository.Object, mockDeskRepository.Object);

            request = new BookDeskRequest()
            {
                FirstName = "Emem",
                LastName = "Isaac",
                Email = "emem-isaac@someniceplace.com",
                Date = new DateTime(2021, 03, 08)
            };

            availableDesks = new List<Desk> { new Desk { Id = 2 } };
            mockDeskRepository.Setup(x => x.GetAvailableDesks(request.Date)).Returns(availableDesks);

        }

        [Fact]
        public void ReturnsDeskBookerRequestResult()
        {
            BookDeskRequestResult result = processor.BookDesk(request);
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
        
        [Fact]
        public void ShouldSaveDeskBooking()
        {
            DeskBooking deskBooking = null;
            mockDeskBookingRepository.Setup(x => x.Save(It.IsAny<DeskBooking>())).Callback<DeskBooking>(booking =>
            {
                deskBooking = booking;
            });
            processor.BookDesk(request);
            mockDeskBookingRepository.Verify(x => x.Save(It.IsAny<DeskBooking>()), Times.Once);
            Assert.NotNull(deskBooking);
            Assert.Equal(deskBooking.FirstName, request.FirstName);
            Assert.Equal(deskBooking.LastName, request.LastName);
            Assert.Equal(deskBooking.Email, request.Email);
            Assert.Equal(deskBooking.Date, request.Date);
            Assert.Equal(availableDesks.First().Id, deskBooking.DeskId);
        }

        [Fact]
        public void ShouldNotSaveDeskBookingIfDeskIsNotAvailable()
        {
            availableDesks.Clear();
            processor.BookDesk(request);
            mockDeskBookingRepository.Verify(x => x.Save(It.IsAny<DeskBooking>()), Times.Never);
        }
    }
}
