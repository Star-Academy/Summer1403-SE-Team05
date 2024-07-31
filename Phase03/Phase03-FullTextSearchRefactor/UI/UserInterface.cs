using Phase03_FullTextSearchRefactor.Interfaces;

namespace Phase03_FullTextSearchRefactor.UI;

internal class UserInterface
{
    private const string ExitCommand = "exit!";

    private readonly IInvertedIndexService _invertedIndex;
    private readonly List<ICommandParserStrategy> _strategies;
    public UserInterface(IInvertedIndexService invertedIndex, IEnumerable<ICommandParserStrategy> strategies)
    {
        _invertedIndex = invertedIndex ?? throw new ArgumentNullException(nameof(invertedIndex));
        _strategies = strategies.ToList() ?? throw new ArgumentNullException(nameof(strategies));
    }
    private UserCriteria ParseCommand(string command)
    {
        var words = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        UserCriteriaBuilder builder = new();
        foreach (var word in words)
        {
            var strategy = _strategies.Single(s => s.CanHandle(word));
            strategy.AddToBuilder(word, builder);
        }

        return builder.Build();
    }
    private void PrintResult(List<string> resultFileNames)
    {
        Logger.LogMessage(Resources.ShowResultMessage);
        Logger.LogMessage(Resources.MessageSeperator);

        if (resultFileNames.Any())
        {
            foreach (var fileName in resultFileNames)
                Logger.LogMessage($"- {fileName}");
        }
        else
            Logger.LogMessage(Resources.NoFilesFoundMessage);

        Logger.LogMessage(Resources.MessageSeperator);
    }
    private bool AskCriteriaFromUser()
    { 
        Console.WriteLine(Resources.AskUserCriteriaMessage);
        var command = Console.ReadLine();
        if (command.Equals(ExitCommand))
            return false;

        var userCriteria = ParseCommand(command);
        var resultFileNames = _invertedIndex.FindDocumentsByCriteria(userCriteria).ToList();

        PrintResult(resultFileNames);
        return true;
    }

    public void RunAskCriteriaFromUserLoop()
    {
        while (AskCriteriaFromUser()) ;
    }
}
