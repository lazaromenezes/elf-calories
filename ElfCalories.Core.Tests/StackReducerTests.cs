namespace ElfCalories.Core.Tests;

public class StackReducerTests {
    
    [Fact]
    public void Reduce_returns_the_sum_of_each_stack(){
        var fullSet = new List<int[]> {
            new int[] {1000, 5000, 10000},
            new int[] {4000},
            new int[] {25000, 25000, 25000, 25000}
        };

        var expected = new int[] {16000, 4000, 100000};

        var reducer = new StackReducer();

        Assert.Equal(expected, reducer.Reduce(fullSet));
    }
}