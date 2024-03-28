using CalcLib.Models;

namespace CalculateArea.Tests
{
    public class CircleTests
    {
        [Fact]
        public void Constructor_ValidRadius_SetsRadius()
        {
            // Arrange
            double radius = 5;

            // Act
            Circle circle = new Circle(radius);

            // Assert
            Assert.Equal(radius, circle.Radius);
        }

        [Fact]
        public void Constructor_NegativeRadius_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            double radius = -1;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(radius));
        }

        [Fact]
        public void Area_ValidRadius_ReturnsCorrectArea()
        {
            // Arrange
            double radius = 5;
            Circle circle = new Circle(radius);
            double expectedArea = Math.PI * radius * radius;

            // Act
            double actualArea = circle.Area();

            // Assert
            Assert.Equal(expectedArea, actualArea, 5);
        }

        [Fact]
        public void Area_VeryLargeRadius_ThrowsOverflowException()
        {
            // Arrange
            double radius = 1e154; // A very large radius that will cause overflow

            // Act & Assert
            Circle circle = new Circle(radius);
            Assert.Throws<OverflowException>(() => circle.Area());
        }
    }
}
