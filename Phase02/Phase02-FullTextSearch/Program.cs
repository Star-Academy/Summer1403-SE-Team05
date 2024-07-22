namespace Phase02_FullTextSearch;

internal class Program
{
    static void Main()
    {
        FileReader fileReader = new();
        var completeFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Resources.DocumentsPath);
        var files = fileReader.ReadAllFiles(completeFilePath);
        var captializedFiles = fileReader.CapitalizeFilesContent(files);
        fileReader.PrintAll(captializedFiles);
    }
}
