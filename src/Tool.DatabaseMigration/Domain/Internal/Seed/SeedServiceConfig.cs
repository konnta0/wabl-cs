using Tool.DatabaseMigration.Domain.Internal.Spreadsheet;
using Tool.DatabaseMigration.Domain.Service.Seed;

namespace Tool.DatabaseMigration.Domain.Internal.Seed;

internal sealed class SeedServiceConfig
{
    public string ApplicationName => nameof(SeedService);
    public string SpreadsheetFolderId => Environment.GetEnvironmentVariable("SPREADSHEET_FOLDER_ID") ?? "A1";
    public string TemplateSpreadsheetId { get; init; } = Environment.GetEnvironmentVariable("TEMPLATE_SPREADSHEET_ID") ?? "A1";
    public SpreadsheetCell TitleCell => new("A2");
    public SpreadsheetCell ColumnNameStartCell => new("B4");
    public SpreadsheetCell ColumnTypeStartCell => new("B5");
    public SpreadsheetCell RowLabelStartCell => new("A7");
    public SpreadsheetCell ColumnLabelStartCell => new("B6");
    public SpreadsheetCell DataStartCell => new("B7");
}