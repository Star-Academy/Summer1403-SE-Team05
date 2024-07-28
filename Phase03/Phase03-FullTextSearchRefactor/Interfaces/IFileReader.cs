using Phase03_FullTextSearchRefactor.Domain;

namespace Phase03_FullTextSearchRefactor.Interfaces;

internal interface IFileReader
{
    public FileContents ReadAllFiles(string filesPath);
}