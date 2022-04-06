using Infrastructure.Extension;

Console.WriteLine("Start Database migration");
var builder = ConsoleApp.CreateBuilder(args);
builder.ConfigureServices((_, collection) =>
{
    collection.AddDbContext();
});

var app = builder.Build();
app.Run();
