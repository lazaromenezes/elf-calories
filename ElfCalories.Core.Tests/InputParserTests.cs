using Moq;

namespace ElfCalories.Core.Tests;

public class InputParserTests {

    [Fact]
    public void Parse_returns_a_collection_of_stacks() {
        var input = "1000\n2000\n3000\n\r\n2000\n5000\n";

        var inputParser = new InputParser();

        var result = inputParser.Parse(input);

        Assert.Equal(2, result.Count());
        Assert.Equal([1000, 2000, 3000], result.ToArray()[0]);
        Assert.Equal([2000, 5000], result.ToArray()[1]);
    }
}