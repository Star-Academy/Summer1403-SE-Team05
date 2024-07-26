using Phase03_FullTextSearchRefactor.Services;
using Phase03_FullTextSearchRefactor.UI;

namespace Phase03_FullTextSearchRefactor;

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
