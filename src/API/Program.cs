var builder = WebApplication.CreateBuilder(args);

AppConfiguration? config = 
    builder.Configuration.GetSection("AppConfiguration").Get<AppConfiguration>();
if(config == null)
{
    Console.WriteLine("Program requires Parser configuration!");
    return;
}

builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.AddSingleton(config);
builder.Services.AddSingleton<ParserRegistry>();
builder.Services.AddScoped<ParseService>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(
    typeof(ParseQueryHandler).Assembly)
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.Urls.Add("http://0.0.0.0:5036");

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

