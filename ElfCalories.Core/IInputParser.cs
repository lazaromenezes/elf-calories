namespace ElfCalories.Core;

public interface IInputParser {
    public IEnumerable<int[]> Parse(string input);
}
