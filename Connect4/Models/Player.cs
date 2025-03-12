namespace Connect4.Models;

public class Player(string color)
{
    public string Color { get; private set; } = color;
}