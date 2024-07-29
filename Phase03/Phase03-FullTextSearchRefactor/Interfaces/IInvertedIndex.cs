namespace Phase03_FullTextSearchRefactor.Interfaces;

internal interface IInvertedIndex
{
    /// <summary>
    /// Add file name to the list of word which shows the files containing that word
    /// </summary>
    void AddWordOccurrence(string word, string fileName);
}