using DbUp;
using DbUp.Helpers;
using System.Reflection;

var connectionString =
        args.FirstOrDefault()
        ?? "Server=127.0.0.1;Port=5432;Database=acuity;User Id=acuity;Password=acuity;";

EnsureDatabase.For.PostgresqlDatabase(connectionString);

var upgrader =
    DeployChanges.To
        .PostgresqlDatabase(connectionString)
        .WithScriptsAndCodeEmbeddedInAssembly(
        Assembly.GetExecutingAssembly(),
        (scriptName) => scriptName.StartsWith("Acuity.Migrations.Scripts"))
        .LogToConsole()
        .Build();

var result = upgrader.PerformUpgrade();

if (!result.Successful)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(result.Error);
    Console.ResetColor();
#if DEBUG
    Console.ReadLine();
#endif
    return -1;
}

var seeder =
    DeployChanges.To
        .PostgresqlDatabase(connectionString)
        .WithScriptsAndCodeEmbeddedInAssembly(
        Assembly.GetExecutingAssembly(),
        (scriptName) => scriptName.StartsWith("Acuity.Migrations.SeedData") && scriptName.EndsWith(".sql"))
        .JournalTo(new NullJournal())
        .LogToConsole()
        .Build();

var seederResult = seeder.PerformUpgrade();

if (!seederResult.Successful)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(seederResult.Error);
    Console.ResetColor();
#if DEBUG
    Console.ReadLine();
#endif
    return -1;
}

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Success!");
Console.ResetColor();
return 0;