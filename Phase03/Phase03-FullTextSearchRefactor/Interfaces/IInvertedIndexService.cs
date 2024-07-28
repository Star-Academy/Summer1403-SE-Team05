namespace Phase03_FullTextSearchRefactor.Interfaces;

internal interface IInvertedIndexService
{
    public IEnumerable<string> FindDocumentsByCriteria(IEnumerable<string> mustWords, IEnumerable<string> atLeast1Word, IEnumerable<string> noWords);
}
