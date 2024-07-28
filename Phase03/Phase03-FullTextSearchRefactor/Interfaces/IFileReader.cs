namespace Phase03_FullTextSearchRefactor.Interfaces;

internal interface IFileReader
{
    public Dictionary<string, string> ReadAllFiles(string filesPath);
}