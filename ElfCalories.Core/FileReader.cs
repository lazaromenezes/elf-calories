namespace ElfCalories.Core;

public class FileReader : IFileReader
{
    public string ReadFile(string path)
    {
       return File.ReadAllText(path);
    }
}