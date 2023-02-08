using Universidade.Domain.Interfaces.Repository;
using Universidade.Domain.Settings;
using Universidade.Infrastructure;
using Universidade.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region AppSettings

var appSetting = builder.Configuration.GetSection(nameof(AppSetting)).Get<AppSetting>();
builder.Services.AddSingleton(appSetting);

#endregion


#region Repositories


builder.Services.AddScoped<IDapperDbConnection, DapperDbConnection>();
builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();
builder.Services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();

#endregion


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
