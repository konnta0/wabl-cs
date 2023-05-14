using System.Text.RegularExpressions;

namespace DatabaseMigration.Command;

public class SpreadsheetCell
{
    public string Row { get; init; }
    public int RowIndex { get; init; }
    public string Column { get; init; }
    public int ColumnIndex { get; init; }

    private string Cell { get; }
    
    public SpreadsheetCell(string cell)
    {
        Cell = cell.ToUpper();
        var match = Regex.Match(cell, @"(?<column>[A-Z]+)(?<row>[0-9]+)");
        if (!match.Success)
        {
            throw new ArgumentException($"Invalid cell format: {cell}");
        }

        Row = match.Groups["row"].Value;
        Column = match.Groups["column"].Value;
        RowIndex = int.Parse(Row);
        // parse column index from A to ZZZ.
        // A = 1, B = 2, ..., Z = 26, AA = 27, AB = 28, ..., ZY = 701, ZZ = 702, AAA = 703, ...
        ColumnIndex = Column.Aggregate(0, (current, c) => current * 26 + c - 'A' + 1);        
    }

    public override string ToString() => Cell;
}