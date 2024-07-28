namespace Phase03_FullTextSearchRefactor.Interfaces;

internal interface IDocumentCapitalizer
{
    public Dictionary<string, string> CapitalizeDocumentsContent(Dictionary<string, string> documentsToCapitalize);
}
