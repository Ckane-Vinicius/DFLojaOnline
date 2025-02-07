using ApiProdutos.Application.Application_Interfaces;
using ApiProdutos.Application.Applications;
using ApiProdutos.Data.Context;
using ApiProdutos.Data.Repository;
using ApiProdutos.Data.Repository_Interfaces;
using ApiProdutos.Domain.Entities;
using ApiProdutos.Domain.Services;
using ApiProdutos.Domain.Services_Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Registro das dependências

//Application
builder.Services.AddScoped<IProdutosApplication, ProdutosApplication>();
//Services
builder.Services.AddScoped<IProdutoServices<Produtos>, ProdutosServices>();
//Repository
builder.Services.AddScoped<IProdutosRepository<Produtos>, ProdutosRepository>();

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
