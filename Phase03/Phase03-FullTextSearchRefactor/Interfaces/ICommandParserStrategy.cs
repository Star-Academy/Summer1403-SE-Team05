using Phase03_FullTextSearchRefactor.UI;

namespace Phase03_FullTextSearchRefactor.Interfaces;

internal interface ICommandParserStrategy
{
    bool CanHandle(string word);
    void AddToBuilder(string word, UserCriteriaBuilder userCriteriaBuilder);
}