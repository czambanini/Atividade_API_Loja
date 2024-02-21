using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using ExercicioLoja.CustomExceptions;

namespace ExercicioLoja.Filters
{
    public class FiltroExcecao : IExceptionFilter
    {

        private readonly ILogger<FiltroExcecao> _logger;
        public FiltroExcecao(ILogger<FiltroExcecao> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            if (context.Exception is CustomException lojaApiException)
            {
                var errorResult = new ErroResponse
                {
                    Titulo = "Erro Loja Api",
                    Detalhes = lojaApiException.Message,
                    StatusCode = lojaApiException.StatusCode
                };

                context.Result = new JsonResult(errorResult)
                {
                    StatusCode = errorResult.StatusCode
                };
            }
            else
            {
                var errorResult = new ErroResponse
                {
                    Titulo = "Erro Loja Api",
                    Detalhes = "Erro interno do servidor",
                    StatusCode = StatusCodes.Status500InternalServerError
                };

                context.Result = new JsonResult(errorResult)
                {
                    StatusCode = errorResult.StatusCode
                };

                _logger.LogError("Uma exceção foi identificada no filtro de exceção");
            }

        }
    }
}
