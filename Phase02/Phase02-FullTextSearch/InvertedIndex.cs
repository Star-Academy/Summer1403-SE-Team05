using System.IO.Enumeration;

namespace Phase02_FullTextSearch;

internal class InvertedIndex
{
    private readonly FileReader _fileReader;
    private Dictionary<string, HashSet<string>> _invertedIndex = new();
    public InvertedIndex(FileReader fileReader)
    {
        _fileReader = fileReader;
    }
    private string[] TokenizeDocument(string document)
    {
        return document.Split(
            new char[] { ' ', '\t', '\r', '\n', ',', '.', ';', ':', '!', '?', '-', '(', ')', '[', ']', '{', '}', '\"', '\'' },
            StringSplitOptions.RemoveEmptyEntries
            );
    }
    private void AddDocumentToInvertedIndex(string completeDocumentPath, string documentContent)
    {
        string fileName = Path.GetFileName(completeDocumentPath);
        string [] documentTokens = TokenizeDocument(documentContent);
        foreach (string token in documentTokens)
        {
            if (!_invertedIndex.ContainsKey(token))
                _invertedIndex[token] = new HashSet<string>();

            _invertedIndex[token].Add(fileName);
        }
    }
    public void FillInvertedIndex(string documentFilesPath)
    {
        var documents = _fileReader.ReadAllFiles(documentFilesPath);
        var captializedDocuments = _fileReader.CapitalizeDocumentsContent(documents);
        foreach (var document in captializedDocuments)
        {
            AddDocumentToInvertedIndex(document.Key, document.Value);
        }
    }
    public IEnumerable<string> FindDocumentsContainingTagetWord(string targetWord)
    {
        var upperTargetWord = targetWord.ToUpper();
        if(_invertedIndex.TryGetValue(upperTargetWord, out var resultDocumentNames))
            return resultDocumentNames;
        else 
            return Enumerable.Empty<string>();
    }
}