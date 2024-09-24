using ElfCalories.Core;
using Microsoft.Extensions.DependencyInjection;

var collection = new ServiceCollection();

collection.AddElfCalories(new AppArgs
{
    InputFilePath = args[0],
    Amount = int.Parse(args[1])
});

var provider = collection.BuildServiceProvider();

var app = provider.GetRequiredService<App>();

app.Run();