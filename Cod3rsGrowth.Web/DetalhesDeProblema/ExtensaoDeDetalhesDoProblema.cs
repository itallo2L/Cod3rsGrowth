using LinqToDB.SqlQuery;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Cod3rsGrowth.Web.DetalhesDeProblema
{
    public static class ExtensaoDeDetalhesDoProblema
    {
        public static void ManipuladorDetalhesDoProblema(this IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseExceptionHandler(construtor =>
            {
                construtor.Run(async contexto =>
                {
                    var erroDoManipuladorDaExcecao = contexto.Features.Get<IExceptionHandlerFeature>();
                    if (erroDoManipuladorDaExcecao != null)
                    {
                        var excecao = erroDoManipuladorDaExcecao.Error;
                        var detalhesDoProblema = new ProblemDetails
                        {
                            Instance = contexto.Request.HttpContext.Request.Path
                        };

                        if (excecao is FluentValidation.ValidationException excecaoDeValidacao)
                        {
                            detalhesDoProblema.Title = "Erro de validação";
                            detalhesDoProblema.Detail = excecaoDeValidacao.Message;
                            detalhesDoProblema.Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1";
                            detalhesDoProblema.Status = StatusCodes.Status400BadRequest;
                        }
                        else if (excecao is SqlException sqlException)
                        {
                            detalhesDoProblema.Title = "Erro no Banco de Dados!";
                            detalhesDoProblema.Detail = sqlException.Message;
                            detalhesDoProblema.Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1";
                            detalhesDoProblema.Status = StatusCodes.Status500InternalServerError;
                        }
                        else
                        {
                            var logger = loggerFactory.CreateLogger("GlobalExceptionHandler");
                            logger.LogError($"Unexpected error: {erroDoManipuladorDaExcecao.Error}");
                            detalhesDoProblema.Title = excecao.Message;
                            detalhesDoProblema.Status = StatusCodes.Status500InternalServerError;
                            detalhesDoProblema.Detail = excecao.Message;
                        }

                        contexto.Response.StatusCode = detalhesDoProblema.Status.Value;
                        contexto.Response.ContentType = "application/problem+json";
                        var json = JsonConvert.SerializeObject(detalhesDoProblema);
                        await contexto.Response.WriteAsync(json);
                    }
                });
            });
        }
    }
}