namespace Phase03_FullTextSearchRefactor.UI;

internal class UserCriteria
{
    public IReadOnlyList<string> RequiredWords { get; }
    public IReadOnlyList<string> AtLeastOneOfTheseWords { get; }
    public IReadOnlyList<string> ExcludedWords { get; }

    public UserCriteria(
        IEnumerable<string> requiredWords,
        IEnumerable<string> atLeastOneOfTheseWords,
        IEnumerable<string> excludedWords
        )
    {
        RequiredWords = new List<string>(requiredWords).AsReadOnly();
        AtLeastOneOfTheseWords = new List<string>(atLeastOneOfTheseWords).AsReadOnly();
        ExcludedWords = new List<string>(excludedWords).AsReadOnly();
    }
}