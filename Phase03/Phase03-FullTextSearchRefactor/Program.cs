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
        try
        {
            var completeFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Resources.DocumentsPath);
            var fileReader = new RawFileReader();
            var invertedIndex = new InvertedIndex();
            var invertedIndexService = new InvertedIndexService(invertedIndex);
            var documentCapitalizer = new DocumentCapitalizer();
            var strategies = new List<ICommandParserStrategy>
            {
                new AtLeastOneWordParserStrategy(),
                new ExcludedWordParserStrategy(),
                new RequiredWordParserStrategy()
            };
            var invertedIndexDataLoader = new InvertedIndexDataLoader(fileReader, invertedIndex, documentCapitalizer);
            invertedIndexDataLoader.FillInvertedIndexFromGivenPath(completeFilePath);
            UserInterface userInterface = new(invertedIndexService, strategies);
            userInterface.RunAskCriteriaFromUserLoop();
        }
        catch (ArgumentNullException ex)
        {
            Logger.LogError(Resources.ArgumentNullError + ex.Message);
        }
        catch (FileNotFoundException ex)
        {
            Logger.LogError(Resources.FileNotFoundError + ex.Message);
        }
        catch (UnauthorizedAccessException ex)
        {
            Logger.LogError(Resources.UnauthorizedAccessError + ex.Message);
        }
        catch (IOException ex)
        {
            Logger.LogError(Resources.IOError + ex.Message);
        }
        catch (Exception ex)
        {
            Logger.LogError(Resources.GeneralError + ex.Message);
        }
    }
}
