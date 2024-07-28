using Phase03_FullTextSearchRefactor.Interfaces;
using Phase03_FullTextSearchRefactor.Utilities;

namespace Phase03_FullTextSearchRefactor.Services.InvertedIndex;

internal class InvertedIndexDataLoader
{
    private readonly IFileReader _fileReader;
    private readonly IInvertedIndex _invertedIndex;
    private readonly IDocumentCapitalizer _documentCapitalizer;
    public InvertedIndexDataLoader(IFileReader fileReader, IInvertedIndex invertedIndex, IDocumentCapitalizer documentCapitalizer)
    {
        ArgumentNullException.ThrowIfNull(fileReader, nameof(fileReader));
        ArgumentNullException.ThrowIfNull(invertedIndex, nameof(invertedIndex));
        ArgumentNullException.ThrowIfNull(documentCapitalizer, nameof(documentCapitalizer));

        _fileReader = fileReader;
        _invertedIndex = invertedIndex;
        _documentCapitalizer = documentCapitalizer;
    }
    private string[] TokenizeDocument(string document)
    {
        return document.Split(
            Delimiters.Characters,
            StringSplitOptions.RemoveEmptyEntries
            );
    }
    private void AddDocumentToInvertedIndex(string completeDocumentPath, string documentContent)
    {
        var fileName = Path.GetFileName(completeDocumentPath);
        var documentTokens = TokenizeDocument(documentContent);

        documentTokens.ToList().ForEach(token =>
        {
            _invertedIndex.AddWord(token, fileName);
        });
    }
    public void FillInvertedIndex(string documentFilesPath)
    {
        var documents = _fileReader.ReadAllFiles(documentFilesPath);
        var capitalizedDocuments = _documentCapitalizer.CapitalizeDocumentsContent(documents);
        foreach (var document in capitalizedDocuments)
        {
            AddDocumentToInvertedIndex(document.Key, document.Value);
        }
    }
}
