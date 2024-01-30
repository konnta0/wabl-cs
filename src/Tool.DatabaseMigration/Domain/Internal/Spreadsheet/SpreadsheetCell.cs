using System.Text.RegularExpressions;

namespace Tool.DatabaseMigration.Domain.Internal.Spreadsheet;

internal class SpreadsheetCell
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

    public SpreadsheetCell(int column, int row)
    {
        RowIndex = row;
        ColumnIndex = column;
        Row = row.ToString();
        Column = string.Empty;
        while (column > 0)
        {
            var remainder = column % 26;
            if (remainder == 0)
            {
                remainder = 26;
            }
            Column = (char)('A' + remainder - 1) + Column;
            column = (column - remainder) / 26;
        }
        Cell = Column + Row;
    }
    
    public override string ToString() => Cell;
}