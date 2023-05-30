using Google.Apis.Auth.OAuth2;

namespace DatabaseMigration.Command;

public interface ISeedService
{
    ValueTask CreateAsync(ICredential credential, string tableGroupName, string tableName);
    ValueTask DownloadAsync(ICredential credential, string outputPath, params string [] tableNames);
    ValueTask RenameLabelsAsync(GoogleCredential credential, string[] labels, string newLabel);
}