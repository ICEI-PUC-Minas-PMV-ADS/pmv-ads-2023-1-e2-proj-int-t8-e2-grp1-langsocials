﻿using Application.Common.Cryptography;
using Application.Common.LangSocialsDb;
using Application.Common.MediatrExtensions;
using FluentResults;
using LangSocials.Domain.Entities;

namespace Application.UseCases.AccountCases.Registration;

public record RegistrationRequest(string Name, string Email, string Password, string? Description) : IResultRequest;

public class RegistrationRequestHandler : IResultRequestHandler<RegistrationRequest>
{
    private readonly ICryptographyService cryptographyService;
    private readonly IUserRepository userRepository;

    public RegistrationRequestHandler(ICryptographyService cryptographyService, IUserRepository userRepository)
    {
        this.cryptographyService = cryptographyService;
        this.userRepository = userRepository;
    }

    public async Task<Result> Handle(RegistrationRequest request, CancellationToken cancellationToken)
    {
        var existingUser = await userRepository.Find(request.Email, cancellationToken);

        // TODO: Refatorar tratamento de erros
        if (existingUser is not null)
            return Result.Fail(new UnhandledError());

        var (hash, salt) = cryptographyService.GenerateHash(request.Password);

        var createdUser = new User
        {
            Name = request.Name,
            Description = request.Description,
            Email = request.Email,
            PasswordHash = hash,
            PasswordSalt = salt,
        };

        await userRepository.Add(createdUser, cancellationToken);

        return Result.Ok();
    }
}

