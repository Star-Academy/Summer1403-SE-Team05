using Phase03_FullTextSearchRefactor.UI;

namespace Phase03_FullTextSearchRefactor.Interfaces;

internal interface IInvertedIndexService
{
    public IEnumerable<string> FindDocumentsByCriteria(UserCriteria userCriteria);
}
