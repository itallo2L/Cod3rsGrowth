using Cod3rsGrowth.Web.InjecaoDeDependencia;

var construtor = WebApplication.CreateBuilder(args);

var loggerFactory = new LoggerFactory();

var servicos = new ServiceCollection();

construtor.Services.AddControllers();
construtor.Services.AddEndpointsApiExplorer();
construtor.Services.AddSwaggerGen();
construtor.AdicionarDependenciasNoEscopo();

var app = construtor.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();