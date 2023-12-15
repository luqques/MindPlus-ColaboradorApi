using MindPlusColaboradorApi.Contracts.Repository;
using MindPlusColaboradorApi.Entity;
using MindPlusColaboradorApi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddTransient<IColaboradorRepository, ColaboradorRepository>();

builder.Services.AddTransient<IAuthenticationRepository, AuthenticationRepository>();

builder.Services.AddTransient<IAvaliacaoRepository, AvaliacaoRepository>();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
