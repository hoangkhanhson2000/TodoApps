using Microsoft.EntityFrameworkCore;
using TodosBackend.Data;
using TodosBackend.Service.Todos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ITodosService, TodosService>();
builder.Services.AddDbContext<TodosDbContext>(option=>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("TodoDatabase"));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Show UseCors with CorsPolicyBuilder
app.UseCors(
    builder =>
    {
        builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
        
    });

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
