using Phase02_FullTextSearch.Services;

namespace Phase02_FullTextSearch.UI;

internal class UserInterface
{
    private readonly InvertedIndex _invertedIndex;
    public UserInterface(InvertedIndex invertedIndex)
    {
        _invertedIndex = invertedIndex;
    }

    private bool AskForTargetWordAndShowResult()
    {
        Console.WriteLine("Enter the word you want to search for: (or exit! for exit)");
        var targetWord = Console.ReadLine();
        if (targetWord.Equals("exit!"))
            return false;

        var resultFileNames = _invertedIndex.FindDocumentsContainingTargetWord(targetWord).ToList();
        Console.WriteLine("\nSearch Results:");
        Console.WriteLine("---------------");

        if (resultFileNames.Any())
        {
            foreach (var fileName in resultFileNames)
                Console.WriteLine($"- {fileName}");
        }
        else
            Console.WriteLine("No files found containing the word.");

        Console.WriteLine("---------------\n");
        return true;
    }

    public void RunAskCriteriaFromUserLoop()
    {
        while (AskForTargetWordAndShowResult()) ;
    }
}
