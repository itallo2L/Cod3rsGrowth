using Cod3rsGrowth.Web.DetalhesDeProblema;
using Cod3rsGrowth.Web.InjecaoDeDependencia;
using Microsoft.Extensions.FileProviders;

var construtor = WebApplication.CreateBuilder(args);

var loggerFactory = new LoggerFactory();

var servicos = new ServiceCollection();

construtor.Services.AddControllers();
construtor.Services.AddEndpointsApiExplorer();
construtor.Services.AddSwaggerGen();
construtor.AdicionarDependenciasNoEscopo();

construtor.Services.AddCors(p => p.AddPolicy("SAPApp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = construtor.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ManipuladorDetalhesDoProblema(app.Services.GetRequiredService<ILoggerFactory>());

app.UseHttpsRedirection();

app.UseCors("SAPApp");

app.UseStaticFiles(new StaticFileOptions { ServeUnknownFileTypes = true });

app.UseFileServer(new FileServerOptions
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(construtor.Environment.ContentRootPath, "wwwroot")),
    EnableDirectoryBrowsing = true
});

app.UseAuthorization();

app.MapControllers();

app.Run();