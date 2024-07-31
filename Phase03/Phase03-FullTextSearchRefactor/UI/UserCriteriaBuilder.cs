using System.Collections.Generic;

namespace Phase03_FullTextSearchRefactor.UI;

internal class UserCriteriaBuilder
{
    private readonly List<string> _requiredWords = new();
    private readonly List<string> _atLeastOneOfTheseWords = new();
    private readonly List<string> _excludedWords = new();
    public void AddRequiredWord(string word)
    {
        _requiredWords.Add(word);
    }

    public void AddAtLeastOneOfTheseWords(string word)
    {
        _atLeastOneOfTheseWords.Add(word);
    }

    public void AddExcludedWord(string word)
    {
        _excludedWords.Add(word);
    }
    public UserCriteria Build()
    {
        return new UserCriteria(
            _requiredWords.AsReadOnly(),
            _atLeastOneOfTheseWords.AsReadOnly(),
            _excludedWords.AsReadOnly());
    }
}