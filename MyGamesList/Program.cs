using MyGamesList;
using MyGamesList.Abstractions;

IArgumentProcessor argumentProcessor = MyGamesList.DependencyInjectorFactory.GetArgumentProcessor();

while (true)
{
    Console.Write("Go to page: ");
    string argument = Console.ReadLine();
    Console.WriteLine();
    argumentProcessor.Process(argument);
    Console.WriteLine();
}
