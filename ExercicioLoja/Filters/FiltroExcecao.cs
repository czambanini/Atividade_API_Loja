using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using ExercicioLoja.CustomExceptions;

namespace ExercicioLoja.Filters
{
    public class FiltroExcecao : IExceptionFilter
    {

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
            }

        }
    }
}
