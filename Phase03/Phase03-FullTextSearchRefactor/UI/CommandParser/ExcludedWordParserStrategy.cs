﻿using Phase03_FullTextSearchRefactor.Interfaces;

namespace Phase03_FullTextSearchRefactor.UI.CommandParser;

internal class ExcludedWordParserStrategy : ICommandParserStrategy
{
    public static readonly char reservedChar = '-';
    public bool CanHandle(string word) => word.StartsWith(reservedChar);

    public void AddToBuilder(string word, UserCriteriaBuilder userCriteriaBuilder)
    {
        userCriteriaBuilder.AddExcludedWord(word.Substring(1));
    }
}
