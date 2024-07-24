namespace Phase02_FullTextSearch.Services;

internal class FileReader
{
    public Dictionary<string, string> ReadAllFiles(string filesPath)
    {
        var filesContent = new Dictionary<string, string>();
        try
        {
            var files = Directory.GetFiles(filesPath);

            foreach (var file in files)
            {
                var content = File.ReadAllText(file);
                filesContent.Add(file, content);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        return filesContent;
    }
    public Dictionary<string, string> CapitalizeDocumentsContent(Dictionary<string, string> filesToCapitalize)
    {
        return filesToCapitalize.ToDictionary(
            file => file.Key,
            file => file.Value.ToUpper()
            );
    }
}