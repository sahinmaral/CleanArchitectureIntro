using CleanArchitectureIntro.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitectureIntro.Domain.Dtos;
using CleanArchitectureIntro.Presentation.Controllers;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using Moq;

namespace CleanArchitectureIntro.UnitTest
{
    public class CarsControllerUnitTest
    {
        [Fact]
        public async void Create_ReturnsOkResult_WhenRequestIsValid()
        {
            var mediatorMock = new Mock<IMediator>();
            var createCarCommand = new CreateCarCommand("Toyota", "Corolla", 122);

            MessageResponse response = new MessageResponse("Araç baþarýyla kaydedildi");

            CancellationToken cancellationToken = new CancellationToken();

            mediatorMock.Setup(m => m.Send(createCarCommand, cancellationToken)).ReturnsAsync(response);

            CarsController carsController = new CarsController(mediatorMock.Object);

            var result = await carsController.Create(createCarCommand, cancellationToken);

            var controllerResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<MessageResponse>(controllerResult.Value);

            Assert.Equal(response, returnValue);

            mediatorMock.Verify(m => m.Send(createCarCommand, cancellationToken), Times.Once);

        }
    }
}