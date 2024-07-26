using Phase03_FullTextSearchRefactor.Interfaces;
using Phase03_FullTextSearchRefactor.Utilities;

namespace Phase03_FullTextSearchRefactor.Services.InvertedIndex;

internal class InvertedIndexFiller
{
    private readonly IFileReader _fileReader;
    private readonly IInvertedIndexService _invertedIndexService;
    public InvertedIndexFiller(IFileReader fileReader, IInvertedIndexService invertedIndexService)
    {
        _fileReader = fileReader;
        _invertedIndexService = invertedIndexService;
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
            _invertedIndexService.AddWord(token, fileName);
        });
    }
    public void FillInvertedIndex(string documentFilesPath)
    {
        var documents = _fileReader.ReadAllFiles(documentFilesPath);
        var capitalizedDocuments = _fileReader.CapitalizeDocumentsContent(documents);
        foreach (var document in capitalizedDocuments)
        {
            AddDocumentToInvertedIndex(document.Key, document.Value);
        }
    }
}
