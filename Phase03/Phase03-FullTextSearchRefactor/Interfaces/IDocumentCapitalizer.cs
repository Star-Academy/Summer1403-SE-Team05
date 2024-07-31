using Phase03_FullTextSearchRefactor.Domain;

namespace Phase03_FullTextSearchRefactor.Interfaces;

internal interface IDocumentCapitalizer
{
    FileContents CapitalizeDocumentsContent(FileContents fileContents);
}
