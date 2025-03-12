using CommunityToolkit.Mvvm.ComponentModel;

namespace Connect4.Models.Boards;

public partial class Slot(int column, int row) : ObservableObject
{
    public int Column { get; private set; } = column;
    public int Row { get; private set; } = row;

    [ObservableProperty]
    private string? _value;

    public void SetValue(string value)
    {
        this.Value = value;
    }
}
