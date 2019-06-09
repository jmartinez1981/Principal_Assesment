using System;
using FluentAssertions;
using Moq;
using Xunit;

namespace TransportManager.Domain.Tests
{
    public class VisitorPatternTests
    {
        private readonly MockRepository mockRepository;

        public VisitorPatternTests()
        {
            mockRepository = new MockRepository(MockBehavior.Default);
        }

        [Fact]
        public void VisitorPattern_Test()
        {
            // Arrange
            const string id = "1234";
            const int priority = 100;
            const int price = 400;

            var stubSample = new Sample(id);
            var visitorMock = mockRepository.Create<IVisitor>();

            visitorMock.Setup(x => x.Visit(It.Is<Sample>(s => s.Id == id)))
                .Callback(() =>
                {
                    stubSample.AssignPriority(priority);
                    stubSample.AssignTestPrice(price);
                });

            // Act
            stubSample.Accept(visitorMock.Object);

            // Assert
            visitorMock.Verify(x => x.Visit(It.Is<Sample>(s => s.Id == id && s.Priority == priority && s.TestPrice == price)), Times.Once);
        }
    }
}
