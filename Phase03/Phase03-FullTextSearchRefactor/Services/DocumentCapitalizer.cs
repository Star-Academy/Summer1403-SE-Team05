using Phase03_FullTextSearchRefactor.Interfaces;

namespace Phase03_FullTextSearchRefactor.Services;

internal class DocumentCapitalizer : IDocumentCapitalizer
{
    public Dictionary<string, string> CapitalizeDocumentsContent(Dictionary<string, string> filesToCapitalize)
    {
        return filesToCapitalize.ToDictionary(
            file => file.Key,
            file => file.Value.ToUpper()
            );
    }
}
