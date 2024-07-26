namespace Phase03_FullTextSearchRefactor.UI;

internal class UserCriteria
{
    public List<string> RequiredWords { get; set; } = new();
    public List<string> AtLeastOneOfTheseWords { get; set; } = new();
    public List<string> ExcludedWords { get; set; } = new();
}