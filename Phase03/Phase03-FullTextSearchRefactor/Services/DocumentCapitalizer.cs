﻿using Phase03_FullTextSearchRefactor.Domain;
using Phase03_FullTextSearchRefactor.Interfaces;

namespace Phase03_FullTextSearchRefactor.Services;

internal class DocumentCapitalizer : IDocumentCapitalizer
{
    public FileContents CapitalizeDocumentsContent(FileContents filesToCapitalize)
    {
        return new FileContents
        {
            Contents = filesToCapitalize.Contents.ToDictionary(
                file => file.Key,
                file => file.Value.ToUpper()
            )
        };
    }
}
