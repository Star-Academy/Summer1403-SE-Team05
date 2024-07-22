namespace Phase02_FullTextSearch;

internal class Program
{
    static void Main()
    {
        FileReader fileReader = new();
        var completeFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Resources.DocumentsPath);
        InvertedIndex invertedIndex = new(fileReader);
        invertedIndex.FillInvertedIndex(completeFilePath);
        var result = invertedIndex.FindFilesContainingTagetWord("MISDIAGNOSED");
        foreach (var file in result)
        {
            Console.WriteLine(file);
        }
    }
}
