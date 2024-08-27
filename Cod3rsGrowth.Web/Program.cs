using Cod3rsGrowth.Infra;
using Cod3rsGrowth.Infra.Repositorios;
using Cod3rsGrowth.Web.DetalhesDeProblema;
using Cod3rsGrowth.Web.InjecaoDeDependencia;
using FluentMigrator.Runner;
using Microsoft.Extensions.FileProviders;

const string testeBancoDeDados = "TesteBancoDeDados";

var construtor = WebApplication.CreateBuilder(args);

if (args.FirstOrDefault() == testeBancoDeDados)
{
    ConnectionString.StringDeConexao = "ConexaoCod3rsGrowthBancoDeTestes";
}

construtor.AdicionarDependenciasNoEscopo();

var loggerFactory = new LoggerFactory();

var servicos = new ServiceCollection();

var app = construtor.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ManipuladorDetalhesDoProblema(app.Services.GetRequiredService<ILoggerFactory>());

using (var scope = app.Services.CreateScope())
{
    var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
    runner.MigrateUp();
}

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

if (args?.FirstOrDefault() == testeBancoDeDados)
{
    using (var escopo = app.Services.CreateScope())
    {
        var servicoTesteBancoDeDados = escopo.ServiceProvider.GetRequiredService<BdCod3rsGrowth>();
        RepositorioDeletarEstudioDeTeste.DeletarEstudioAdicionadoEmTeste(servicoTesteBancoDeDados);
    }
}

app.Run();