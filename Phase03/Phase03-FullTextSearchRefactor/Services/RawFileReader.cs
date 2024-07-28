using Phase03_FullTextSearchRefactor.Interfaces;

namespace Phase03_FullTextSearchRefactor.Services;

internal class RawFileReader : IFileReader
{
    public Dictionary<string, string> ReadAllFiles(string filesPath)
    {
        var filesContent = new Dictionary<string, string>();
        var files = Directory.GetFiles(filesPath);
        filesContent = files.ToDictionary(file => file, file => File.ReadAllText(file));
        return filesContent;
    }
}