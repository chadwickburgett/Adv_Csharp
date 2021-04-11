using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ticketingBurgett.Models;
using ticketingBurgett.Controllers;

namespace TicketScheduleTests
{
    public class HomeControllerTest
    {
        [Fact]
        public void IndexActionMethod_ReturnsAViewResult()
        {
            // arrange
            var unit = new Mock<ITicketScheduleUnitOfWork>();
            var tickets = new Mock<IRepository<Ticket>>();
            var days = new Mock<IRepository<Day>>();
            unit.Setup(r => r.Tickets).Returns(tickets.Object);
            unit.Setup(r => r.Days).Returns(days.Object);

            var http = new Mock<IHttpContextAccessor>();

            var controller = new HomeController(unit.Object, http.Object);

            // act
            var result = controller.Index(0);

            // assert
            Assert.IsType<ViewResult>(result);
        }
    }
}