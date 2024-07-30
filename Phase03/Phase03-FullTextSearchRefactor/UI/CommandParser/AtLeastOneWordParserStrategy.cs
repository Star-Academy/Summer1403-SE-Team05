﻿using Phase03_FullTextSearchRefactor.Interfaces;

namespace Phase03_FullTextSearchRefactor.UI.CommandParser;

internal class AtLeastOneWordParserStrategy : ICommandParserStrategy
{
    public static readonly char reservedCharacter = '+';
    public bool CanHandle(string word) => word.StartsWith(reservedCharacter);

    public void AddToBuilder(string word, UserCriteriaBuilder userCriteriaBuilder)
    {
        userCriteriaBuilder.AddAtLeastOneOfTheseWords(word.Substring(1));
    }
}