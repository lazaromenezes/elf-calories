namespace ElfCalories.Core;

public interface IInputParser {
    public IEnumerable<int[]> Parse(string input);
}

public interface IFileInputReader {
    int[] ReadInputFile(string inputFilePath);
}