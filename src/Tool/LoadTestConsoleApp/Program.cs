
var builder = ConsoleApp.CreateBuilder(args);
builder.ConfigureServices((ctx,services) =>
{
});

var app = builder.Build();
app.AddAllCommandType();
app.Run();