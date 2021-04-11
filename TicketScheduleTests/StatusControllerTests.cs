using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ticketingBurgett.Models;
using ticketingBurgett.Controllers;

namespace TicketScheduleTests
{
    public class StatusControllerTests
    {
        [Fact]
        public void IndexActionMethod_ReturnsAViewResult()
        {
            // arrange
            var rep = new Mock<IRepository<Status>>();
            var controller = new StatusController(rep.Object);

            // act
            var result = controller.Index();

            // assert
            Assert.IsType<ViewResult>(result);

        }
    }
}
