using Infrastructure.Extension;

Console.WriteLine("Start Database migration");
var builder = ConsoleApp.CreateBuilder(args);
builder.ConfigureServices((context, collection) =>
{
    collection.AddInfrastructure(context.Configuration);
});
var app = builder.Build();
app.Run();
