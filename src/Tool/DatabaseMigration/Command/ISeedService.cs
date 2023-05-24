using Google.Apis.Auth.OAuth2;

namespace DatabaseMigration.Command;

public interface ISeedService
{
    ValueTask CreateAsync(ICredential credential, string tableGroupName, string tableName);
    ValueTask RenameLabelsAsync(GoogleCredential credential, string[] labels, string newLabel);
}