using MyGamesList;
using MyGamesList.Abstractions;

DependencyInjectorFactory dependencyInjector = new DependencyInjectorFactory();
IArgumentProcessor argumentProcessor = dependencyInjector.GetArgumentProcessor();

while (true)
{
    Console.Write("Go to page: ");
    string argument = Console.ReadLine();
    Console.WriteLine();
    argumentProcessor.Process(argument);
    Console.WriteLine();
}
