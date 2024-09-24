
namespace ElfCalories.Core;

public class App
{
    private AppArgs arguments;
    private IOutputWriter outputWritter;
    private readonly IFileInputReader fileInputReader;
    private readonly ICaloriesSummer caloriesSummer;

    public App(AppArgs arguments, IOutputWriter outputWritter, IFileInputReader fileInputReader, ICaloriesSummer caloriesSummer)
    {
        this.arguments = arguments;
        this.outputWritter = outputWritter;
        this.fileInputReader = fileInputReader;
        this.caloriesSummer = caloriesSummer;
    }

    public void Run()
    {
        var input = fileInputReader.ReadInputFile(arguments.InputFilePath);
        var result = caloriesSummer.SumCalories(input, arguments.Amount);

        outputWritter.Write($"Total: {result}");
    }
}