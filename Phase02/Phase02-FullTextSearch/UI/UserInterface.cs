using Phase02_FullTextSearch.Services;

namespace Phase02_FullTextSearch.UI;

internal class UserInterface
{
    private readonly InvertedIndex _invertedIndex;
    public UserInterface(InvertedIndex invertedIndex)
    {
        _invertedIndex = invertedIndex;
    }
    private (List<string>, List<string>, List<string>) ParseCommand(string command)
    {
        List<string> andWords = new List<string>();
        List<string> orWords = new List<string>();
        List<string> notWords = new List<string>();

        var words = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        foreach (var word in words)
        {
            if (word.StartsWith('+'))
                orWords.Add(word.Substring(1));
            else if (word.StartsWith('-'))
                notWords.Add(word.Substring(1));
            else
                andWords.Add(word);
        }

        return (andWords, orWords, notWords);
    }
    private void AskCriteriaFromUser()
    {
        Console.WriteLine("Enter criteria: (No prefix for AND words, + prefix for OR words, - prefix for NOT words");
        var command = Console.ReadLine();
        (List<string> andWords, List<string> orWords, List<string> notWords) = ParseCommand(command);
        var resultFileNames = _invertedIndex.FindDocumentsByCriteria(andWords, orWords, notWords);
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
    }

    public void StartInteractingWithUser()
    {
        while (true)
            AskCriteriaFromUser();
    }
}
