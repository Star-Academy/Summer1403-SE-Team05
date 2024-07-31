using Phase03_FullTextSearchRefactor.Interfaces;

namespace Phase03_FullTextSearchRefactor.UI.CommandParser;

internal class RequiredWordParserStrategy : ICommandParserStrategy
{
    public bool CanHandle(string word) => ReservedCharacters.Characters.All(ch => !word.StartsWith(ch));

    public void AddToBuilder(string word, UserCriteriaBuilder userCriteriaBuilder)
    {
        userCriteriaBuilder.AddRequiredWord(word);
    }
}
