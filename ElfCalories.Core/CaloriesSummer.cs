namespace ElfCalories.Core;

public interface ICaloriesSummer {
    int SumCalories(int[] caloriesToSum, int amount);
}

public class CaloriesSummer() : ICaloriesSummer
{
    public int SumCalories(int[] caloriesToSum, int amount)
    {
        if (caloriesToSum.Length == 0)
            throw new ArgumentException("List can't be empty");

        if (caloriesToSum.Any(c => c < 0))
            throw new ArgumentException("List can't contain negative numbers");

        return caloriesToSum.OrderDescending().Take(amount).Sum();
    }
}
