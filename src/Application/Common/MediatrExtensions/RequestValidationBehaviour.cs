using FluentResults;
using FluentValidation;
using MediatR;

namespace Application.Common.MediatrExtensions;

public class RequestValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : ResultBase, new()
{
    private readonly IEnumerable<IValidator<TRequest>> validators;

    public RequestValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        this.validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (validators.Any())
        {
            var contexto = new ValidationContext<TRequest>(request);

            var resultadosValidacoes = await Task.WhenAll(validators.Select(v => v.ValidateAsync(contexto, cancellationToken)));

            var dicionarioCampoMotivos = resultadosValidacoes
                .SelectMany(result => result.Errors)
                .GroupBy(error => error.PropertyName)
                .ToDictionary(errorGroup => errorGroup.Key, errorGroup => errorGroup.Select(e => e.ErrorMessage).ToArray());

            if (dicionarioCampoMotivos.Count != 0)
                return Result.Fail(new RequestValidationError() { FieldErrorsDictionary = dicionarioCampoMotivos }).To<TResponse>();
        }

        return await next();
    }
}
