using Microsoft.AspNetCore.Mvc.Filters;

namespace ExercicioLoja.Filters
{
    public class FiltroLogAcoes : IActionFilter
    {
        private readonly ILogger<FiltroLogAcoes> _logger;
        public FiltroLogAcoes(ILogger<FiltroLogAcoes> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var descricao = context.ActionDescriptor.DisplayName;
            _logger.LogInformation($"A ação {descricao} terminou de ser executada.");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var descricao = context.ActionDescriptor.DisplayName;
            _logger.LogInformation($"A ação {descricao} começou a ser executada.");
        }
    }
}
