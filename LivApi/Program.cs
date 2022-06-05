using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using LivApi.Data;
using LivApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var sqlConBuilder = new SqlConnectionStringBuilder();
sqlConBuilder.ConnectionString = builder.Configuration.GetConnectionString("AppDbConnection");
sqlConBuilder.UserID = builder.Configuration["UserID"];
sqlConBuilder.Password = builder.Configuration["Password"];

//builder.Services.AddDbContext<TodoItemsContext>(opt => opt.UseSqlServer(sqlConBuilder.ConnectionString));
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(sqlConBuilder.ConnectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "Hello World!");
/*
app.MapGet("/todoitems", async (TodoItemsContext db) =>
    await db.Todos.ToListAsync());

app.MapGet("/todoitems/complete", async (TodoItemsContext db) =>
    await db.Todos.Where(t => t.IsComplete).ToListAsync());

app.MapGet("/todoitems/{id}", async (int id, TodoItemsContext db) =>
    await db.Todos.FindAsync(id)
        is Todo todo
        ? Results.Ok(todo)
        : Results.NotFound());

app.MapPost("/todoitems", async (Todo todo, TodoItemsContext db) =>
{
    db.Todos.Add(todo);
    await db.SaveChangesAsync();

    return Results.Created($"/todoitems/{todo.Id}", todo);
});

app.MapPut("/todoitems/{id}", async (int id, Todo inputTodo, TodoItemsContext db) =>
{
    var todo = await db.Todos.FindAsync(id);

    if (todo is null) return Results.NotFound();

    todo.Name = inputTodo.Name;
    todo.IsComplete = inputTodo.IsComplete;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/todoitems/{id}", async (int id, TodoItemsContext db) =>
{
    if (await db.Todos.FindAsync(id) is Todo todo)
    {
        db.Todos.Remove(todo);
        await db.SaveChangesAsync();
        return Results.Ok(todo);
    }

    return Results.NotFound();
});
*/

// Insurance
app.MapGet("/api/insurances", async (AppDbContext db) => await db.Insurances.ToListAsync());
app.MapGet("/api/insurance/{id}", async (AppDbContext db, int id) =>
    await db.Insurances.FindAsync(id)
        is Insurance insurance
        ? Results.Ok(insurance)
        : Results.NotFound());

app.MapPost("/api/insurance", async (AppDbContext db, Insurance insurance) =>
{
    await db.Insurances.AddAsync(insurance);
    await db.SaveChangesAsync();
    return Results.Created($"/api/insurance/{insurance.InsuranceId}", insurance);
});
app.MapPut("/api/insurance/{id}", async (int id, Insurance inputInsurance, AppDbContext db) =>
{
    var insurance = await db.Insurances.FindAsync(id);
    if (insurance is null) return Results.NotFound();
    insurance.Sex = inputInsurance.Sex;
    insurance.z = inputInsurance.z;
    insurance.GuaranteeAmount = inputInsurance.GuaranteeAmount;
    insurance.PaymentTime = inputInsurance.PaymentTime;
    insurance.GuaranteeTime = inputInsurance.GuaranteeTime;
    insurance.Product = inputInsurance.Product;
    insurance.Table = inputInsurance.Table;
    
    await db.SaveChangesAsync();
    return Results.NoContent();
});
app.MapDelete("/api/insurance/{id}", async (int id, AppDbContext db) =>
{
    if (await db.Insurances.FindAsync(id) is Insurance insurance)
    {
        db.Insurances.Remove(insurance);
        await db.SaveChangesAsync();
        return Results.Ok(insurance);
    }
    return Results.NotFound();
});

app.Run();