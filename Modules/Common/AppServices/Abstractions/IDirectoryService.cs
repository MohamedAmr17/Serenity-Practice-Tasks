
namespace Serene2;

public interface IDirectoryService
{
    AppServices.DirectoryEntry Validate(string username, string password);
}