﻿using Phase03_FullTextSearchRefactor.Interfaces;

namespace Phase03_FullTextSearchRefactor.UI.CommandParser;

internal class AtLeastOneWordParserStrategy : ICommandParserStrategy
{
    public static readonly char ReservedCharacter = '+';
    public bool CanHandle(string word) => word.StartsWith(ReservedCharacter);

    public void AddToBuilder(string word, UserCriteriaBuilder userCriteriaBuilder)
    {
        userCriteriaBuilder.AddAtLeastOneOfTheseWords(word.Substring(1));
    }
}