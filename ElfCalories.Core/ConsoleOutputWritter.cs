namespace ElfCalories.Core;

class ConsoleOutputWriter : IOutputWriter
{
    public void Write(string output)
    {
        Console.WriteLine(output);
    }
}