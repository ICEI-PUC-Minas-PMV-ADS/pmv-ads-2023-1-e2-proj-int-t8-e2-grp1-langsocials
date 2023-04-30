using FluentResults;
using MediatR;

namespace Application.Common.MediatrExtensions;

public interface IResultRequestHandler<TRequest> : IRequestHandler<TRequest, Result>
    where TRequest : IRequest<Result>
{
}

public interface IResultRequestHandler<TRequest, TValue> : IRequestHandler<TRequest, Result<TValue>>
    where TRequest : IRequest<Result<TValue>>
{ }
