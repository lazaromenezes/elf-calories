using Moq;

namespace ElfCalories.Core.Tests;

public class AppTests {
    
    [Fact]
    public void Should_write_the_sum_of_the_x_higher_stacks_in_file(){
        const int FINAL_OUTPUT = 30000;
        var input = new int[]{10000, 6000, 3000, 2000, 1000, 5000};

        var arguments = new AppArgs {
            InputFilePath = "./test-input",
            Amount = 3
        };

        var fileReader = new Mock<IFileInputReader>();
        fileReader.Setup(fr => fr.ReadInputFile(arguments.InputFilePath)).Returns(input);

        var caloriesSummer = new Mock<ICaloriesSummer>();
        caloriesSummer.Setup(cs => cs.SumCalories(input, arguments.Amount)).Returns(FINAL_OUTPUT);

        var outputWritter = new Mock<IOutputWriter>();

        var app = new App(arguments, outputWritter.Object, fileReader.Object, caloriesSummer.Object);

        app.Run();

        outputWritter.Verify(o => o.Write($"Total: {FINAL_OUTPUT}"));
    }
}