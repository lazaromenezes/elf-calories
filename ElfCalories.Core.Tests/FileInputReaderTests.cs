using Moq;

namespace ElfCalories.Core.Tests;

public class FileInputReaderTests {

    [Fact]
    public void Returns_an_array_of_int_based_on_file_input(){
        const string FILE_PATH = "/some/input/file";
        const string FILE_CONTENT = "SOME_CONTENT";
        var PARSED_CONTENT = new List<int[]> {
            new int[] {100, 200, 300},
            new int[] {300, 400, 600}
        };

        var PARSED_INPUT = new int[] {900, 800};

        var fileReader = new Mock<IFileReader>();
        fileReader.Setup(fr => fr.ReadFile(FILE_PATH)).Returns("SOME_CONTENT");

        var inputParser = new Mock<IInputParser>();
        inputParser.Setup(ip => ip.Parse(FILE_CONTENT)).Returns(PARSED_CONTENT);
        
        var reducer = new Mock<IStackReducer>();
        reducer.Setup(r => r.Reduce(PARSED_CONTENT)).Returns(PARSED_INPUT);

        var fileInputReader = new FileInputReader(fileReader.Object, inputParser.Object, reducer.Object);

        var result = fileInputReader.ReadInputFile(FILE_PATH);

        Assert.Equal(PARSED_INPUT, result);
    }
}