using Microsoft.Extensions.Logging;
using Phase03_FullTextSearchRefactor.Interfaces;
using Phase03_FullTextSearchRefactor.Services;
using Phase03_FullTextSearchRefactor.Services.InvertedIndex;
using Phase03_FullTextSearchRefactor.UI;
using Phase03_FullTextSearchRefactor.UI.CommandParser;

namespace Phase03_FullTextSearchRefactor;

internal class Program
{
    private static void Main()
    {
        ILogger logger = LoggerFactory.Create(builder => builder.AddConsole()).CreateLogger<Program>();
        try
        {
            var fileReader = new RawFileReader();
            var invertedIndex = new InvertedIndex();
            var documentCapitalizer = new DocumentCapitalizer();
            var invertedIndexDataLoader = new InvertedIndexDataLoader(fileReader, invertedIndex, documentCapitalizer);
            var completeFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Resources.DocumentsPath);
            invertedIndexDataLoader.FillInvertedIndexFromGivenPath(completeFilePath);
            var strategies = new List<ICommandParserStrategy>
            {
                new AtLeastOneWordParserStrategy(),
                new ExcludedWordParserStrategy(),
                new RequiredWordParserStrategy()
            };
            var invertedIndexService = new InvertedIndexService(invertedIndex);
            UserInterface userInterface = new(invertedIndexService, strategies);
            userInterface.RunAskCriteriaFromUserLoop();
        }
        catch (ArgumentNullException ex)
        {
            Logger.LogError(Resources.ArgumentNullError + ex.Message);
        }
    }
}
