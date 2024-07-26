using Phase03_FullTextSearchRefactor.Services;
using Phase03_FullTextSearchRefactor.Services.InvertedIndex;
using Phase03_FullTextSearchRefactor.UI;

namespace Phase03_FullTextSearchRefactor;

internal class Program
{
    private static void Main()
    {
        var completeFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Resources.DocumentsPath);
        RawFileReader fileReader = new();
        InvertedIndexService invertedIndexService = new();
        InvertedIndexFiller invertedIndexFiller = new(fileReader, invertedIndexService);
        invertedIndexFiller.FillInvertedIndex(completeFilePath);
        UserInterface userInterface = new(invertedIndexService);
        userInterface.RunAskCriteriaFromUserLoop();
    }
}
