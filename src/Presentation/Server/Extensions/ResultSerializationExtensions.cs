using Application.Common.MediatrExtensions;
using FluentResults;

namespace LangSocials.Presentation.Server.Extensions;

public static class ResultSerializationExtensions
{
    public static IResult Serialize(this Result result)
    {
        if (result.IsSuccess)
            return Results.Ok();

        if (result.Errors.FirstOrDefault(a => a is UnhandledError) is UnhandledError unhandledError)
            return Results.Problem(detail: unhandledError.Message, statusCode: 403);
            

        if (result.Errors.FirstOrDefault(a => a is RequestValidationError) is RequestValidationError requestValidationError)
            return Results.ValidationProblem(requestValidationError.FieldErrorsDictionary);

        return Results.Problem(statusCode: 500);
    }

    public static IResult Serialize<TValue>(this Result<TValue> result)
    {
        if (result.IsSuccess)
            return Results.Ok(result.Value);

        return result.ToResult().Serialize();
    }
}
