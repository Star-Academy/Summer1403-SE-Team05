using Phase03_FullTextSearchRefactor.Interfaces;
using Phase03_FullTextSearchRefactor.Utilities;

namespace Phase03_FullTextSearchRefactor.Services.InvertedIndex;

internal class InvertedIndexService : IInvertedIndexService
{
    private Dictionary<string, HashSet<string>> _invertedIndex = new();
    private HashSet<string> _allDocumentsName = new HashSet<string>();

    public void AddWord(string word, string fileName)
    {
        if (!_invertedIndex.ContainsKey(word))
            _invertedIndex[word] = new HashSet<string>();

        _invertedIndex[word].Add(fileName);
        _allDocumentsName.Add(fileName);
    }

    private IEnumerable<string> FindDocumentsContainingTargetWord(string targetWord)
    {
        var upperTargetWord = targetWord.ToUpper();
        if (_invertedIndex.TryGetValue(upperTargetWord, out var resultDocumentNames))
            return resultDocumentNames;
        else
            return Enumerable.Empty<string>();
    }
    private IEnumerable<string> FindRequiredWordsDocuments(List<string> words)
    {
        if (words.Count == 0)
            return _invertedIndex.Values.SelectMany(v => v);
        var allDocuments = _allDocumentsName.AsEnumerable();
        return words.Aggregate(
            allDocuments,
            (current, word) => current.Intersect(FindDocumentsContainingTargetWord(word))
            );
    }
    private IEnumerable<string> FindExcludedWordsDocuments(List<string> words)
    {
        if (words.Count == 0)
            return _invertedIndex.Values.SelectMany(v => v);
        var allDocuments = _allDocumentsName.AsEnumerable();
        return words.Aggregate(
            allDocuments,
            (current, word) => current.Intersect(allDocuments.Except(FindDocumentsContainingTargetWord(word)))
            );
    }
    private IEnumerable<string> FindAtLeastOneOfTheseWordsDocuments(List<string> words)
    {
        if (words.Count == 0)
            return _invertedIndex.Values.SelectMany(v => v);
        var allDocuments = _allDocumentsName.AsEnumerable();
        return allDocuments.Except(FindExcludedWordsDocuments(words));
    }
    public IEnumerable<string> FindDocumentsByCriteria(List<string> mustWords, List<string> atLeast1Word, List<string> noWords)
    {
        return FindRequiredWordsDocuments(mustWords)
            .Intersect(FindAtLeastOneOfTheseWordsDocuments(atLeast1Word))
            .Intersect(FindExcludedWordsDocuments(noWords));
    }
}