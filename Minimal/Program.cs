var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Default", builder =>
    {
        builder.AllowAnyOrigin();
    });
});

builder.Services.AddHttpClient();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();


app.MapGet("/", () => "Hello World!");

app.MapGet("/users", (int userCount) =>
{
    return Results.Ok($"Retuns {userCount}");
})
.WithName("Get orders");

app.Run();
