
using ElfCalories.Core;

namespace ElfCalorires.Core;

public class CaloriesSummer
{
    private IReducedListProvider listProvider;

    public CaloriesSummer(IReducedListProvider listProvider)
    {
        this.listProvider = listProvider;
    }

    public int SumCalories(){
        return SumCalories(listProvider.GetList());
    }

     private int SumCalories(int[] caloriesToSum)
    {
        if (!caloriesToSum.Any())
            throw new ArgumentException("List can't be empty");

        if(caloriesToSum.Any(c => c < 0))
            throw new ArgumentException("List can't contain negative numbers");

        return caloriesToSum.OrderDescending().Take(3).Sum();
    }
}
