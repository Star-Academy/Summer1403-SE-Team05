namespace Phase02_FullTextSearch;

internal class InvertedIndex
{
    private readonly FileReader _fileReader;
    private Dictionary<string, HashSet<string>> _invertedIndex = new();
    public InvertedIndex(FileReader fileReader)
    {
        _fileReader = fileReader;
    }
    private string[] TokenizeFile(string text)
    {
        return text.Split(
            new char[] { ' ', '\t', '\r', '\n', ',', '.', ';', ':', '!', '?', '-', '(', ')', '[', ']', '{', '}', '\"', '\'' },
            StringSplitOptions.RemoveEmptyEntries
            );
    }
    private void AddFileToInvertedIndex(string fileName, string fileContent)
    {
        string [] tokens = TokenizeFile(fileContent);
        foreach (string token in tokens)
        {
            if (!_invertedIndex.ContainsKey(token))
                _invertedIndex[token] = new HashSet<string>();

            _invertedIndex[token].Add(fileName);
        }
    }
    public void FillInvertedIndex(string documentsPath)
    {
        var files = _fileReader.ReadAllFiles(documentsPath);
        var captializedFiles = _fileReader.CapitalizeFilesContent(files);
        foreach (var file in captializedFiles)
        {
            AddFileToInvertedIndex(file.Key, file.Value);
        }
    }
}
