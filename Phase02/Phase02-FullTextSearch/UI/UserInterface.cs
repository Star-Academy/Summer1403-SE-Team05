using Phase02_FullTextSearch.Services;

namespace Phase02_FullTextSearch.UI;

internal class UserInterface
{
    private readonly InvertedIndex _invertedIndex;
    public UserInterface(InvertedIndex invertedIndex)
    {
        _invertedIndex = invertedIndex;
    }

    private void AskForTargetWordAndShowResult()
    {
        Console.WriteLine("Enter the word you want to search for:");
        var targetWord = Console.ReadLine();
        var resultFileNames = _invertedIndex.FindDocumentsContainingTagetWord(targetWord);
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
    }

    public void StartInteractingWithUser()
    {
        while (true)
            AskForTargetWordAndShowResult();
    }
}
