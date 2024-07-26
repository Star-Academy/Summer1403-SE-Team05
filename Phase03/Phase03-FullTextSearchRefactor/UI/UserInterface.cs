using Phase03_FullTextSearchRefactor.Interfaces;

namespace Phase03_FullTextSearchRefactor.UI;

internal class UserInterface
{
    private readonly IInvertedIndexService _invertedIndex;
    public UserInterface(IInvertedIndexService invertedIndex)
    {
        _invertedIndex = invertedIndex;
    }
    private UserCriteria ParseCommand(string command)
    {
        UserCriteria userCriteria = new();
        var words = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        
        foreach (var word in words)
        {
            if (word.StartsWith('+'))
                userCriteria.AtLeastOneOfTheseWords.Add(word.Substring(1));
            else if (word.StartsWith('-'))
                userCriteria.ExcludedWords.Add(word.Substring(1));
            else
                userCriteria.RequiredWords.Add(word);
        }

        return userCriteria;
    }
    private bool AskCriteriaFromUser()
    { 
        Console.WriteLine("Enter criteria: (No prefix for AND words, + prefix for OR words, - prefix for NOT words, exit! for exit");
        var command = Console.ReadLine();
        if (command.Equals("exit!"))
            return false;

        var userCriteria = ParseCommand(command);
        var resultFileNames = _invertedIndex.FindDocumentsByCriteria(
            userCriteria.RequiredWords,
            userCriteria.AtLeastOneOfTheseWords,
            userCriteria.ExcludedWords).
            ToList();

        Console.WriteLine("\nSearch Results:");
        Console.WriteLine("---------------");

        if (resultFileNames.Any())
        {
            foreach (var fileName in resultFileNames)
                Console.WriteLine($"- {fileName}");
        }
        else
            Console.WriteLine("No files found containing the criteria.");

        Console.WriteLine("---------------\n");
        return true;
    }

    public void RunAskCriteriaFromUserLoop()
    {
        while (AskCriteriaFromUser()) ;
    }
}
