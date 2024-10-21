using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Leonardo.Data;
using Leonardo.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlite("Data Source=Gabriel_Leonardo.db"));

var app = builder.Build();



// Rotas para gerenciar abrigos
app.MapPost("api/funcionario/cadastrar", async ([FromBody] Funcionario funcionario, [FromServices] AppDbContext ctx) =>
{
    ctx.Funcionarios.Add(funcionario);
    await ctx.SaveChangesAsync();
    return Results.Created($"/funcionario/cadastrar{funcionario.FuncionarioId}", funcionario);
});

app.MapGet("api/funcionario/listar", async ([FromServices] AppDbContext ctx) =>
{
    var funcionarios = await ctx.Funcionarios.ToListAsync();
    return funcionarios.Any() ? Results.Ok(funcionarios) : Results.NotFound();
});


app.MapPost("/adopet/animais/cadastrar", async ([FromBody] Animal animal, [FromServices] AppDbContext ctx) =>
{
    ctx.Animais.Add(animal);
    await ctx.SaveChangesAsync();
    return Results.Created($"/adopet/animais/{animal.AnimalId}", animal);
});

/*app.MapGet("/adopet/animais/listar", async ([FromServices] AppDbContext ctx) =>
{
    var animais = await ctx.Animais.ToListAsync();
    return animais.Any() ? Results.Ok(animais) : Results.NotFound();
});

app.MapPut("/adopet/animais/{id}", async (int id, [FromBody] Animal animalAtualizado, [FromServices] AppDbContext ctx) =>
{
    var animal = await ctx.Animais.FindAsync(id);
    if (animal == null)
    {
        return Results.NotFound();
    }
    animal.Nome = animalAtualizado.Nome;
    animal.Especie = animalAtualizado.Especie;
    animal.Raca = animalAtualizado.Raca;
    animal.Idade = animalAtualizado.Idade;
    animal.DisponivelParaAdocao = animalAtualizado.DisponivelParaAdocao;
    animal.AbrigoId = animalAtualizado.AbrigoId;
    await ctx.SaveChangesAsync();
    return Results.Ok(animal);
});

app.MapDelete("/adopet/animais/{id}", async (int id, [FromServices] AppDbContext ctx) =>
{
    var animal = await ctx.Animais.FindAsync(id);
    if (animal == null) return Results.NotFound();
    ctx.Animais.Remove(animal);
    await ctx.SaveChangesAsync();
    return Results.NoContent();
});*/
app.Run();

