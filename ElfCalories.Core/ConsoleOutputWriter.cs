namespace ElfCalories.Core;

public class ConsoleOutputWriter : IOutputWriter
{
    public void Write(string output)
    {
        Console.WriteLine(output);
    }
}