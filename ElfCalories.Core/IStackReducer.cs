namespace ElfCalories.Core;

public interface IStackReducer
{
    int[] Reduce(IEnumerable<int[]> stacks);
}
