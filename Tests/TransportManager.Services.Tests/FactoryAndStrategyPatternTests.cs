using System;
using System.Collections.Generic;
using FluentAssertions;
using Moq;
using TransportManager.Services.Factory;
using TransportManager.Services.Strategy;
using Xunit;

namespace TransportManager.Services.Tests
{
    public class FactoryAndStrategyPatternTests
    {
        private readonly MockRepository mockRepository;

        public FactoryAndStrategyPatternTests()
        {
            mockRepository = new MockRepository(MockBehavior.Default);
        }

        [Fact]
        public void Factory_Returns_Valid_Strategy()
        {
            // Arrange
            const string operationId = "1";
            const string sampleId = "11";

            var strategyMock = mockRepository.Create<IOperationStrategy>();
            strategyMock.Setup(x => x.IsValid(operationId)).Returns(true);
            var strategiesMock = new List<IOperationStrategy>{strategyMock.Object};
            var stubFactory = new OperationFactory(strategiesMock);

            // Act
            var result = stubFactory.GetOperation(operationId, sampleId);

            // Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public void Factory_Returns_Null_Strategy()
        {
            // Arrange
            const string operationId = "1";
            const string sampleId = "11";

            var strategyMock = mockRepository.Create<IOperationStrategy>();
            strategyMock.Setup(x => x.IsValid(operationId)).Returns(false);
            var strategiesMock = new List<IOperationStrategy> { strategyMock.Object };
            var stubFactory = new OperationFactory(strategiesMock);

            // Act
            var result = stubFactory.GetOperation(operationId, sampleId);

            // Assert
            result.Should().BeNull();
        }
    }
}
