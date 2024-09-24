namespace ElfCalories.Core;

public class FileInputReader(IFileReader fileReader, IInputParser inputParser, IStackReducer reducer) : IFileInputReader
{
    private readonly IFileReader fileReader = fileReader;
    private readonly IInputParser inputParser = inputParser;
    private readonly IStackReducer reducer = reducer;

    public int[] ReadInputFile(string inputFilePath)
    {
        var inputText = fileReader.ReadFile(inputFilePath);

        var parsedInput = inputParser.Parse(inputText);

        return reducer.Reduce(parsedInput);
    }
}