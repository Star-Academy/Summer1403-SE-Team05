using Phase03_FullTextSearchRefactor.Domain;

namespace Phase03_FullTextSearchRefactor.Interfaces;

internal interface IDocumentCapitalizer
{
    public FileContents CapitalizeDocumentsContent(FileContents fileContents);
}
