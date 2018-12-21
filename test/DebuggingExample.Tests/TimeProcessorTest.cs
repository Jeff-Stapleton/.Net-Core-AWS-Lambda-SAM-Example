using System;
using DebuggingExample.Services;
using Xunit;

namespace DebuggingExample.Tests
{
    public class TimeProcessorTest
    {
        [Fact]
        public void TestCurrentTimeUtc()
        {
            // Arrange
            var processor = new TimeService();
            var preTestTimeUtc = DateTime.UtcNow;

            // Act
            var result = processor.CurrentTimeUTC();

            // Assert time moves forwards 
            var postTestTimeUtc = DateTime.UtcNow;
            Assert.True(result >= preTestTimeUtc);
            Assert.True(result <= postTestTimeUtc);
        }
    }
}
