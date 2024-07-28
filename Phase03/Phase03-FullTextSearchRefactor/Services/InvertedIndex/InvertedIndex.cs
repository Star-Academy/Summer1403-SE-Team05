using Phase03_FullTextSearchRefactor.Interfaces;

namespace Phase03_FullTextSearchRefactor.Services.InvertedIndex;

internal class InvertedIndex : IInvertedIndex
{
    public Dictionary<string, HashSet<string>> InvertedIndexMap { get; } = new();
    public HashSet<string> AllDocumentsName { get; } = new();

    public void AddWord(string word, string fileName)
    {
        if (!InvertedIndexMap.ContainsKey(word))
            InvertedIndexMap[word] = new HashSet<string>();

        InvertedIndexMap[word].Add(fileName);
        AllDocumentsName.Add(fileName);
    }
}
