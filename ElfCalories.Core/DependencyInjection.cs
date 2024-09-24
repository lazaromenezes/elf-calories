using System;
using Microsoft.Extensions.DependencyInjection;

namespace ElfCalories.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddElfCalories(this IServiceCollection collection, AppArgs args)
    {
        collection.AddSingleton(args);
        
        collection.AddTransient<App>();

        collection.AddTransient<IOutputWriter, ConsoleOutputWriter>();

        collection.AddTransient<IFileInputReader, FileInputReader>();
        collection.AddTransient<ICaloriesSummer, CaloriesSummer>();

        collection.AddTransient<IStackReducer, StackReducer>();
        collection.AddTransient<IInputParser, InputParser>();
        collection.AddTransient<IFileReader, FileReader>();

        return collection;
    }
}
