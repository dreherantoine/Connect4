namespace Connect4UI.Models;

public class Player(string color)
{
    public string Color { get; private set; } = color;
}