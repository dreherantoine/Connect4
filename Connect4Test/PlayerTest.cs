using Connect4Models;
using FluentAssertions;

namespace Connect4Test;

public class PlayerTest
{
    [Fact]
    public void Initialize_ReturnChar()
    {
        // Arrange
        Player player = new Player("Red");

        // Act
        string expectedColor = player.Color;

        // Assert
        expectedColor
            .Should()
            .Be("Red");
    }
}
