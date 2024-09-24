namespace ElfCalories.Core;

public class StackReducer : IStackReducer
{
    public int[] Reduce(IEnumerable<int[]> stacks)
    {
        return stacks.Select(s => s.Sum()).ToArray();
    }
}