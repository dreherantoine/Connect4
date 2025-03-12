using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using static System.Reflection.Metadata.BlobBuilder;

namespace Connect4.Models.Boards;

public class Board
{
    public ObservableCollection<Slot> Grid { get; private set; }

    public Board()
    {
        this.Grid = InitiliazeGrid();
    }

    private static ObservableCollection<Slot> InitiliazeGrid()
    {
        ObservableCollection<Slot> grid = new ObservableCollection<Slot>();

        for (int row = 0; row < 6; row++)
        {
            for (int column = 0; column < 7; column++)
            {
                grid.Add(new Slot(column, row));
            }
        }

        return grid;
    }

    public bool PlayerMove(int column, string color)
    {
        Slot? slot = this.Grid
            .Where(slot => slot.Column == column)
            .Where(slot => slot.Value == null)
            .LastOrDefault();

        if (slot == null)
            return false;

        slot.SetValue(color);

        return true;
    }

    public bool IsGameWin()
    {
        IEnumerable<IGrouping<int, Slot>> columns = this.Grid
            .GroupBy(Slot => Slot.Column);

        IEnumerable<IGrouping<int, Slot>> rows = this.Grid
            .GroupBy(Slot => Slot.Row);

        if (IsFourConsecutive(columns) || IsFourConsecutive(rows))
        {
            return true;
        }

        return false;
    }

    private static bool IsFourConsecutive(IEnumerable<IGrouping<int, Slot>> grid)
    {
        return false;
    }
}
