
using ElfCalories.Core;

internal class Program
{
    private static void Main(params string[] args)
    {
        var arguments = new AppArgs{
            InputFilePath = args[0],
            Amount = int.Parse(args[1])
        };

        var outputWritter = new ConsoleOutputWriter();
        var reducer = new StackReducer();
        var inputParser = new InputParser();
        var fileReader = new FileReader();

        var reader = new FileInputReader(fileReader, inputParser, reducer);
        var summer = new CaloriesSummer();

        var app = new App(arguments, outputWritter, reader, summer);

        app.Run();
    }
}