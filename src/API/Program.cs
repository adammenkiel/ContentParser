var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();

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

