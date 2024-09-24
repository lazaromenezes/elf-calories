namespace ElfCalories.Core;

public class App(AppArgs arguments, IOutputWriter outputWritter, IFileInputReader fileInputReader, ICaloriesSummer caloriesSummer)
{
    private readonly AppArgs arguments = arguments;
    private readonly IOutputWriter outputWritter = outputWritter;
    private readonly IFileInputReader fileInputReader = fileInputReader;
    private readonly ICaloriesSummer caloriesSummer = caloriesSummer;

    public void Run()
    {
        var input = fileInputReader.ReadInputFile(arguments.InputFilePath);
        var result = caloriesSummer.SumCalories(input, arguments.Amount);

        outputWritter.Write($"Total: {result}");
    }
}