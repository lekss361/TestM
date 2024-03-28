using CalcLib.Models;

namespace CalculateArea.Tests
{
    public class TriangleTests
    {
        [Fact]
        public void Constructor_ValidSides_SetsSides()
        {
            // Arrange
            double sideA = 3;
            double sideB = 4;
            double sideC = 5;

            // Act
            Triangle triangle = new Triangle(sideA, sideB, sideC);

            // Assert
            Assert.Equal(sideA, triangle.SideA);
            Assert.Equal(sideB, triangle.SideB);
            Assert.Equal(sideC, triangle.SideC);
        }

        [Fact]
        public void Constructor_NegativeSide_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            double sideA = -1;
            double sideB = 4;
            double sideC = 5;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(sideA, sideB, sideC));
        }

        [Fact]
        public void Area_ValidSides_ReturnsCorrectArea()
        {
            // Arrange
            double sideA = 3;
            double sideB = 4;
            double sideC = 5;
            Triangle triangle = new Triangle(sideA, sideB, sideC);
            double expectedArea = 6;

            // Act
            double actualArea = triangle.Area();

            // Assert
            Assert.Equal(expectedArea, actualArea, 5);
        }

        [Fact]
        public void IsTriangleRectangle_ValidSides_ReturnsTrue()
        {
            // Arrange
            double sideA = 3;
            double sideB = 4;
            double sideC = 5;
            Triangle triangle = new Triangle(sideA, sideB, sideC);

            // Act
            bool result = triangle.IsTriangleRectangle();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsTriangleRectangle_InvalidSides_ReturnsFalse()
        {
            // Arrange
            double sideA = 2;
            double sideB = 3;
            double sideC = 4;
            Triangle triangle = new Triangle(sideA, sideB, sideC);

            // Act
            bool result = triangle.IsTriangleRectangle();

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Area_SidesCauseOverflow_ThrowsOverflowException()
        {
            // Arrange
            double sideA = 1e154;
            double sideB = 1e154;
            double sideC = 1e154;

            // Act & Assert
            Triangle triangle = new Triangle(sideA, sideB, sideC);
            Assert.Throws<OverflowException>(() => triangle.Area());
        }

        [Fact]
        public void IsTriangleRectangle_SidesCauseOverflow_ThrowsOverflowException()
        {
            // Arrange
            double sideA = 1e154;
            double sideB = 1e154;
            double sideC = 1e154;

            // Act & Assert
            Triangle triangle = new Triangle(sideA, sideB, sideC);
            Assert.Throws<OverflowException>(() => triangle.IsTriangleRectangle());
        }

        [Fact]
        public void IsTriangle_InvalidSides_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            double sideA = 5;
            double sideB = 10;
            double sideC = 5;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(sideA, sideB, sideC));
        }
    }
}
