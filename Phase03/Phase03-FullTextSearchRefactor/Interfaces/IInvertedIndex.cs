namespace Phase03_FullTextSearchRefactor.Interfaces;

internal interface IInvertedIndex
{
    public void AddWord(string word, string fileName);
}