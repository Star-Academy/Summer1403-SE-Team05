namespace Phase03_FullTextSearchRefactor.Interfaces;

internal interface IFileReader
{
    public Dictionary<string, string> ReadAllFiles(string filesPath);
    public Dictionary<string, string> CapitalizeDocumentsContent(Dictionary<string, string> filesToCapitalize);
}