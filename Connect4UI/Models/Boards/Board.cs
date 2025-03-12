namespace Connect4UI.Models.Boards;

public class Board
{
    public List<Slot> Grid { get; private set; }

    public Board()
    {
        this.Grid = InitiliazeGrid();
    }

    private static List<Slot> InitiliazeGrid()
    {
        List<Slot> grid = new List<Slot>();

        for (int column = 0; column < 7; column++)
        {
            for (int row = 0; row < 6; row++)
            {
                grid.Add(new Slot(column, row));
            }
        }

        return grid;
    }

    public bool PlayerMove(int column, string color)
    {
        Slot? Slot = this.Grid
            .Where(Slot => Slot.Column == column)
            .Where(Slot => Slot.Value == null)
            .LastOrDefault();

        if (Slot == null)
            return false;

        Slot.SetValue(color);

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
        // Not implemented yet
        return true;
    }
}
