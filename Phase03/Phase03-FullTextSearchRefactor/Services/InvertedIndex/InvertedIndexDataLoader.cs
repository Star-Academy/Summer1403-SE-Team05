using Phase03_FullTextSearchRefactor.Domain;
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
        _fileReader = fileReader ?? throw new ArgumentNullException(nameof(fileReader));
        _invertedIndex = invertedIndex ?? throw new ArgumentNullException(nameof(invertedIndex));
        _documentCapitalizer = documentCapitalizer ?? throw new ArgumentNullException(nameof(documentCapitalizer));
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
            _invertedIndex.AddWordOccurrence(token, fileName);
        });
    }
    public void FillInvertedIndexFromGivenPath(string documentFilesPath)
    {
        FileContents fileContents = _fileReader.ReadAllFiles(documentFilesPath);
        FileContents capitalizedDocuments = _documentCapitalizer.CapitalizeDocumentsContent(fileContents);
        foreach (var document in capitalizedDocuments.Contents)
        {
            AddDocumentToInvertedIndex(document.Key, document.Value);
        }
    }
}
