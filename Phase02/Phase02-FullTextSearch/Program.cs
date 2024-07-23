using Phase02_FullTextSearch.Services;
using Phase02_FullTextSearch.UI;

namespace Phase02_FullTextSearch;

internal class Program
{
    private static void Main()
    {
        FileReader fileReader = new();
        var completeFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Resources.DocumentsPath);
        InvertedIndex invertedIndex = new(fileReader);
        invertedIndex.FillInvertedIndex(completeFilePath);
        UserInterface userInterface = new(invertedIndex);
        userInterface.RunAskCriteriaFromUserLoop();
    }
}
