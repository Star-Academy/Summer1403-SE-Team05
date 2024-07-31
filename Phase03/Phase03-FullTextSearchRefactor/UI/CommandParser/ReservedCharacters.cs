namespace Phase03_FullTextSearchRefactor.UI.CommandParser;

internal class ReservedCharacters
{
    public static readonly char[] Characters =
        [
            AtLeastOneWordParserStrategy.ReservedCharacter,
            ExcludedWordParserStrategy.ReservedCharacter
        ];
}
