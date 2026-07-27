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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

