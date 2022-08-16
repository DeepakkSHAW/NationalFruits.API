using Microsoft.AspNetCore.Mvc;
using NationalFruits.API.Services;
using NationalFruits.API.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSingleton<INationalFruitsRepository, NationalFruitsRepository>();
//builder.Services.AddSingleton<IFruitsRepo, FruitsRepo>();
builder.Services.AddSingleton< FruitsRepo>();

var app = builder.Build();
app.UseSwagger();
app.MapGet("/", () => "National Fruits API. Open Swagger: https://localhost:7004/swagger/index.html");

app.MapGet("nationalfruit/api", async ([FromServices] FruitsRepo frepo) =>
{
    //int i = frepo.AllFruits().Count();
    return frepo.AllFruits();
});

app.MapGet("nationalfruit/api/{id}", async ([FromServices] FruitsRepo frepo, int id) =>
{
    var vResult = frepo.GetFruitById(id);
    return vResult is not null ? Results.Ok(vResult) : Results.NotFound();
});

app.MapDelete("nationalfruit/api/{id}", async ([FromServices] FruitsRepo frepo, int id) =>
{
    frepo.RemoveFruit(id);
    return Results.NoContent();
});

app.MapPost("nationalfruit/api", async ([FromServices] FruitsRepo frepo, Fruit fruit) =>
{
    frepo.AddFruit(fruit);
    return Results.Created($"nationalfruit/api/{fruit.Id}", fruit);
});

app.MapPut("nationalfruit/api/{id}", async ([FromServices] FruitsRepo frepo, int id, Fruit fruit) =>
{
    var vResult = frepo.GetFruitById(id);
    if (vResult is null)
    {
        return Results.NotFound();  
    }
    fruit.Id = id;
    frepo.UpdateFruit(fruit);
    return Results.Ok(vResult);
});

app.UseSwaggerUI();
app.Run();
