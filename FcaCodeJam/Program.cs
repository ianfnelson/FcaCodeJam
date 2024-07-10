
using System.Diagnostics;
using System.Reflection;
using Autofac;
using FcaCodeJam.Weeks;

var container = BuildContainer();

var weeks = container.Resolve<IEnumerable<IWeek>>();
var week = GetWeek();

var inputPath = $"InputFiles/{week.InputFile}";

var sw = new Stopwatch();
sw.Start();

foreach (var line in week.DoPuzzle(inputPath))
{
    Console.WriteLine(line);
}
sw.Stop();

Console.WriteLine();
Console.WriteLine($"Elapsed ticks: {sw.ElapsedTicks}");

return;

IContainer BuildContainer()
{
    var builder = new ContainerBuilder();
    builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces();
    return builder.Build();
}

IWeek GetWeek()
{
    if (args.Length == 0)
    {
        return weeks.MaxBy(x => x.Name) ?? throw new InvalidOperationException();
    }

    return weeks.Single(x => x.Name == args[0]);
}