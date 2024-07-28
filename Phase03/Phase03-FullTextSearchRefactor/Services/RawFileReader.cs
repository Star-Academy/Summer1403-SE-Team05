using Phase03_FullTextSearchRefactor.Interfaces;
using Phase03_FullTextSearchRefactor.Domain;

namespace Phase03_FullTextSearchRefactor.Services;

internal class RawFileReader : IFileReader
{
    public FileContents ReadAllFiles(string filesPath)
    {
        var filesContents = new FileContents();
        var files = Directory.GetFiles(filesPath);
        filesContents.Contents = files.ToDictionary(file => file, file => File.ReadAllText(file));
        return filesContents;
    }
}