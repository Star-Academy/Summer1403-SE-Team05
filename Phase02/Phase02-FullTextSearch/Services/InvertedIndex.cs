<<<<<<< HEAD
﻿using System.IO.Enumeration;

=======
﻿using Phase02_FullTextSearch.Utilities;
>>>>>>> 0266b29 (refactor: some cleaning)
namespace Phase02_FullTextSearch.Services;

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
            Delimiters.Characters,
            StringSplitOptions.RemoveEmptyEntries
            );
    }
    private void AddDocumentToInvertedIndex(string completeDocumentPath, string documentContent)
    {
        string fileName = Path.GetFileName(completeDocumentPath);
        string[] documentTokens = TokenizeDocument(documentContent);
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
        var capitalizedDocuments = _fileReader.CapitalizeDocumentsContent(documents);
        foreach (var document in capitalizedDocuments)
        {
            AddDocumentToInvertedIndex(document.Key, document.Value);
        }
    }
<<<<<<< HEAD
    public IEnumerable<string> FindDocumentsContainingTagetWord(string targetWord)
=======
    private IEnumerable<string> FindDocumentsContainingTargetWord(string targetWord)
>>>>>>> 0266b29 (refactor: some cleaning)
    {
        var upperTargetWord = targetWord.ToUpper();
        if (_invertedIndex.TryGetValue(upperTargetWord, out var resultDocumentNames))
            return resultDocumentNames;
        else
            return Enumerable.Empty<string>();
    }
<<<<<<< HEAD
=======
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
>>>>>>> 0266b29 (refactor: some cleaning)
}