namespace DatabaseMigration.Command.SeedCreate;

public class SeedCreateConfig
{
    public string ApplicationName => "SeedCreate";
    public string SpreadsheetFolderId => Environment.GetEnvironmentVariable("SPREADSHEET_FOLDER_ID") ?? throw new ArgumentNullException(nameof(TemplateSpreadsheetId));
    public string TemplateSpreadsheetId { get; init; } = Environment.GetEnvironmentVariable("TEMPLATE_SPREADSHEET_ID") ?? throw new ArgumentNullException(nameof(TemplateSpreadsheetId));
    public SpreadsheetCell TitleCell => new("A2");
    public SpreadsheetCell DescriptionCell => new("B2");
}