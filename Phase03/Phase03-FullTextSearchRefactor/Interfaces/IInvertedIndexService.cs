namespace Phase03_FullTextSearchRefactor.Interfaces;

internal interface IInvertedIndexService
{
    public IEnumerable<string> FindDocumentsByCriteria(List<string> mustWords, List<string> atLeast1Word, List<string> noWords);
    public void AddWord(string word, string fileName);
}
