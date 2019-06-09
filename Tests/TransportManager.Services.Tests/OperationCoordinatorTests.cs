using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using TransportManager.Services.Factory;
using TransportManager.Services.Strategy;
using Xunit;

namespace TransportManager.Services.Tests
{
    public class OperationCoordinatorTests
    {
        private readonly MockRepository mockRepository;

        public OperationCoordinatorTests()
        {
            mockRepository = new MockRepository(MockBehavior.Default);
        }

        [Fact]
        public void Test()
        {
            // Arrange
            const string operations = "1,2,3";
            var operationsCount = operations.Split(",").Length;

            var configMock = mockRepository.Create<IConfiguration>();
            var configSectionMock = this.mockRepository.Create<IConfigurationSection>();
            var factoryMock = mockRepository.Create<IOperationFactory>();
            var strategyMock = mockRepository.Create<IOperationStrategy>();

            configMock.Setup(c => c.GetSection(It.IsAny<string>())).Returns(configSectionMock.Object);
            configSectionMock.Setup(x => x.Value).Returns(operations);
         
            factoryMock.Setup(x => x.GetOperation(It.IsAny<string>(), It.IsAny<string>())).Returns(strategyMock.Object);

            var coordinator = new OperationCoordinator(factoryMock.Object, configMock.Object);

            // Act
            coordinator.Execute();

            // Assert
            factoryMock.Verify(x => x.GetOperation(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(operationsCount));
            strategyMock.Verify(x => x.Perform(), Times.Exactly(operationsCount));
        }
    }
}
