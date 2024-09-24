using Moq;

namespace ElfCalories.Core.Tests;

public class CaloriesSummerTests
{
    readonly CaloriesSummer caloriesSummer;

    public CaloriesSummerTests()
    {
        caloriesSummer = new CaloriesSummer();
    }

    [Theory]
    [InlineData(new int[] {6000, 4000, 5000, 1000, 1000}, 15000)]
    [InlineData(new int[] {6000, 4000, 11000, 24000, 10000}, 45000)]
    [InlineData(new int[] {6000, 24000, 11000, 4000, 10000}, 45000)]
    [InlineData(new int[] {4000, 6000, 11000, 24000, 10000}, 45000)]
    [InlineData(new int[] {11000, 4000, 5000, 24000, 10000}, 45000)]
    public void Test_SumCalories_Returns_Correct_Value(int[] input, int expected){
        var result = caloriesSummer.SumCalories(input, 3);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new int[] {6000, 4000, 5000, 1000, 1000}, 3, 15000)]
    [InlineData(new int[] {6000, 4000, 11000, 24000, 10000}, 1, 24000)]
    [InlineData(new int[] {6000, 24000, 11000, 4000, 10000}, 3, 45000)]
    [InlineData(new int[] {4000, 6000, 11000, 24000, 10000}, 2, 35000)]
    [InlineData(new int[] {11000, 4000, 5000, 24000, 10000}, 4, 50000)]
    public void Test_SumCalories_Returns_Correct_Value_based_on_amount(int[] input, int amount, int expected){
        var result = caloriesSummer.SumCalories(input, amount);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Test_SumCalories_Throws_When_List_Is_Empty(){
        var ex = Assert.Throws<ArgumentException>(() => {
            var result = caloriesSummer.SumCalories([], 3);
        });

        Assert.Equal("List can't be empty", ex.Message);
    }

    [Fact]
    public void Test_Exception_Alternative(){
        try
        {
            var result = caloriesSummer.SumCalories([], 3);
            Assert.Fail();
        }catch (ArgumentException)
        {
            Assert.True(true);
        }
    }

    [Fact]
    public void Test_SumCalories_Throws_When_List_Contains_A_Negative_Value(){
        var ex = Assert.Throws<ArgumentException>(() => {
            var result = caloriesSummer.SumCalories([-1, 2, 3], 3);
        });

        Assert.Equal("List can't contain negative numbers", ex.Message);
    }
}