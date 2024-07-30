using Phase03_FullTextSearchRefactor.Interfaces;
using Phase03_FullTextSearchRefactor.UI;

namespace Phase03_FullTextSearchRefactor.Services.InvertedIndex;

internal class InvertedIndexService : IInvertedIndexService
{
    private InvertedIndex _invertedIndex;
    public InvertedIndexService(InvertedIndex invertedIndex)
    {
        ArgumentNullException.ThrowIfNull(invertedIndex, nameof(invertedIndex));
        _invertedIndex = invertedIndex;
    }
    private IEnumerable<string> FindDocumentsContainingTargetWord(string targetWord)
    {
        var upperTargetWord = targetWord.ToUpper();
        if (_invertedIndex.InvertedIndexMap.TryGetValue(upperTargetWord, out var resultDocumentNames))
            return resultDocumentNames;
        else
            return Enumerable.Empty<string>();
    }
    private IEnumerable<string> FindRequiredWordsDocuments(IReadOnlyCollection<string> words)
    {
        if (!words.Any())
            return _invertedIndex.InvertedIndexMap.Values.SelectMany(v => v);
        var allDocuments = _invertedIndex.AllDocumentsName.AsEnumerable();
        return words.Aggregate(
            allDocuments,
            (current, word) => current.Intersect(FindDocumentsContainingTargetWord(word))
            );
    }
    private IEnumerable<string> FindExcludedWordsDocuments(IReadOnlyCollection<string> words)
    {
        if (!words.Any())
            return _invertedIndex.InvertedIndexMap.Values.SelectMany(v => v);
        var allDocuments = _invertedIndex.AllDocumentsName.AsEnumerable();
        return words.Aggregate(
            allDocuments,
            (current, word) => current.Intersect(allDocuments.Except(FindDocumentsContainingTargetWord(word)))
            );
    }
    private IEnumerable<string> FindAtLeastOneOfTheseWordsDocuments(IReadOnlyCollection<string> words)
    {
        if (!words.Any())
            return _invertedIndex.InvertedIndexMap.Values.SelectMany(v => v);
        var allDocuments = _invertedIndex.AllDocumentsName.AsEnumerable();
        return allDocuments.Except(FindExcludedWordsDocuments(words));
    }
    public IEnumerable<string> FindDocumentsByCriteria(UserCriteria userCriteria)
    {
        return FindRequiredWordsDocuments(userCriteria.RequiredWords)
            .Intersect(FindAtLeastOneOfTheseWordsDocuments(userCriteria.AtLeastOneOfTheseWords))
            .Intersect(FindExcludedWordsDocuments(userCriteria.ExcludedWords));
    }
}