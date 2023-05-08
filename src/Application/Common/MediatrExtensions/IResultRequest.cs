using FluentResults;
using MediatR;

namespace Application.Common.MediatrExtensions;

public interface IResultRequest : IRequest<Result> { }
public interface IResultRequest<TValue> : IRequest<Result<TValue>> { }
