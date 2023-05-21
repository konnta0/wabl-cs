namespace DatabaseMigration.Command;

public class SeedServiceConfig
{
    public string ApplicationName => nameof(SeedService);
    public string SpreadsheetFolderId => Environment.GetEnvironmentVariable("SPREADSHEET_FOLDER_ID") ?? throw new ArgumentNullException(nameof(TemplateSpreadsheetId));
    public string TemplateSpreadsheetId { get; init; } = Environment.GetEnvironmentVariable("TEMPLATE_SPREADSHEET_ID") ?? throw new ArgumentNullException(nameof(TemplateSpreadsheetId));
    public SpreadsheetCell TitleCell => new("A2");
    public SpreadsheetCell DescriptionCell => new("B2");
    public SpreadsheetCell RowLabelStartCell => new("A7");
    public SpreadsheetCell ColumnLabelStartCell => new("B6");
}