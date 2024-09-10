using ElfCalorires.Core;
using Moq;

namespace ElfCalories.Core.Tests;

public class CaloriesSummerTests
{

    CaloriesSummer caloriesSummer;
    Mock<IReducedListProvider> listProvider;

    public CaloriesSummerTests()
    {
        listProvider = new Mock<IReducedListProvider>();
        caloriesSummer = new CaloriesSummer(listProvider.Object);
    }

    [Theory]
    [InlineData(new int[] {6000, 4000, 5000, 1000, 1000}, 15000)]
    [InlineData(new int[] {6000, 4000, 11000, 24000, 10000}, 45000)]
    [InlineData(new int[] {6000, 24000, 11000, 4000, 10000}, 45000)]
    [InlineData(new int[] {4000, 6000, 11000, 24000, 10000}, 45000)]
    [InlineData(new int[] {11000, 4000, 5000, 24000, 10000}, 45000)]
    public void Test_SumCalories_Returns_Correct_Value(int[] input, int expected){
        listProvider.Setup(p => p.GetList()).Returns(input);

        var result = caloriesSummer.SumCalories();

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Test_SumCalories_Throws_When_List_Is_Empty(){
        listProvider.Setup(p => p.GetList()).Returns([]);

        var ex = Assert.Throws<ArgumentException>(() => {
            var result = caloriesSummer.SumCalories();
        });

        Assert.Equal("List can't be empty", ex.Message);
    }

    [Fact]
    public void Test_Exception_Alternative(){
        listProvider.Setup(p => p.GetList()).Returns([]);

        try {
            var result = caloriesSummer.SumCalories();
            Assert.Fail();
        }catch(ArgumentException e){
            Assert.True(true);
        }
    }

    [Fact]
    public void Test_SumCalories_Throws_When_List_Contains_A_Negative_Value(){
        listProvider.Setup(p => p.GetList()).Returns([-1, 2, 3]);

        var ex = Assert.Throws<ArgumentException>(() => {
            var result = caloriesSummer.SumCalories();
        });

        Assert.Equal("List can't contain negative numbers", ex.Message);
    }
}