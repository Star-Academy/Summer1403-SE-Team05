using Phase02_FullTextSearch.Utilities;
namespace Phase02_FullTextSearch.Services;

internal class InvertedIndex
{
    private readonly FileReader _fileReader;
    private Dictionary<string, HashSet<string>> _invertedIndex = new();
    private HashSet<string> _allDocumentsName = new HashSet<string>();
    public InvertedIndex(FileReader fileReader)
    {
        _fileReader = fileReader;
    }
    private string[] TokenizeDocument(string document)
    {
        return document.Split(
            Delimiters.Characters,
            StringSplitOptions.RemoveEmptyEntries
            );
    }
    private void AddDocumentToInvertedIndex(string completeDocumentPath, string documentContent)
    {
        var fileName = Path.GetFileName(completeDocumentPath);
        var documentTokens = TokenizeDocument(documentContent);
        documentTokens.ToList().ForEach(token =>
        {
            if (!_invertedIndex.ContainsKey(token))
                _invertedIndex[token] = new HashSet<string>();

            _invertedIndex[token].Add(fileName);
            _allDocumentsName.Add(fileName);
        });
    }
    public void FillInvertedIndex(string documentFilesPath)
    {
        var documents = _fileReader.ReadAllFiles(documentFilesPath);
        var capitalizedDocuments = _fileReader.CapitalizeDocumentsContent(documents);
        foreach (var document in capitalizedDocuments)
        {
            AddDocumentToInvertedIndex(document.Key, document.Value);
        }
    }
    private IEnumerable<string> FindDocumentsContainingTargetWord(string targetWord)
    {
        var upperTargetWord = targetWord.ToUpper();
        if (_invertedIndex.TryGetValue(upperTargetWord, out var resultDocumentNames))
            return resultDocumentNames;
        else
            return Enumerable.Empty<string>();
    }
    private IEnumerable<string> FindMustWordsDocuments(List<string> words)
    {
        if (words.Count == 0)
            return _invertedIndex.Values.SelectMany(v => v);
        var allDocuments = _allDocumentsName.AsEnumerable();
        return words.Aggregate(
            allDocuments,
            (current, word) => current.Intersect(FindDocumentsContainingTargetWord(word))
            );
    }
    private IEnumerable<string> FindNoWordsDocuments(List<string> words)
    {
        if (words.Count == 0)
            return _invertedIndex.Values.SelectMany(v => v);
        var allDocuments = _allDocumentsName.AsEnumerable();
        return words.Aggregate(
            allDocuments,
            (current, word) => current.Intersect(allDocuments.Except(FindDocumentsContainingTargetWord(word)))
            );
    }
    private IEnumerable<string> FindAtLeast1WordsDocument(List<string> words)
    {
        if(words.Count == 0)
            return _invertedIndex.Values.SelectMany(v => v);
        var allDocuments = _allDocumentsName.AsEnumerable();
        return allDocuments.Except(FindNoWordsDocuments(words));
    }
    public IEnumerable<string> FindDocumentsByCriteria(List<string> mustWords, List<string> atLeast1Word, List<string> noWords)
    {
        return FindMustWordsDocuments(mustWords)
            .Intersect(FindAtLeast1WordsDocument(atLeast1Word))
            .Intersect(FindNoWordsDocuments(noWords));
    }
}