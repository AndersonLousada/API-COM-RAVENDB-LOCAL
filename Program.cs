using ApiTesteRavenDb.Infra;
using Raven.Client.Documents;
using Raven.Migrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IDocumentStore>(opcoes => ControladorDeDocumentos.Store);

builder.Services.AddRavenDbMigrations();
var migrationService = builder.Services.BuildServiceProvider()
    .GetRequiredService<MigrationRunner>();
migrationService.Run();

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
