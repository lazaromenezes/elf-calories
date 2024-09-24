namespace ElfCalories.Core;

public class InputParser : IInputParser
{
    const string STACK_SEPARATOR = "\n\n";
    const string ITEM_SEPARATOR = "\n";

    public IEnumerable<int[]> Parse(string input) => input.Split(STACK_SEPARATOR).Select(ParseStack);

    private static int[] ParseStack(string input) => input.Split(ITEM_SEPARATOR).Select(ParseItem).ToArray();

    private static int ParseItem(string input) => int.Parse(input);
}