﻿namespace Connect4UI.Models.Boards;

public class Slot(int column, int row)
{
    public int Column { get; private set; } = column;
    public int Row { get; private set; } = row;
    public string? Value { get; private set; }

    public void SetValue(string value)
    {
        this.Value = value;
    }
}
