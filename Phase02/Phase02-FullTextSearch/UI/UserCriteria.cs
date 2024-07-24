namespace Phase02_FullTextSearch.UI;

internal class UserCriteria
{
    public List<string> RequiredWords { get; set; } = new();
    public List<string> AtLeastOneOfTheseWords { get; set; } = new();
    public List<string> ExcludedWords { get; set; } = new();
}