using System.Runtime.CompilerServices;
using Contracts;
using CSharpFunctionalExtensions;
using MediatR;
using PasswordManager.Core;
using PasswordManager.Infrastructure;

namespace PasswordManager.Application;

public class CreateEmailAddressPasswordCommandHandler : IRequestHandler<CreateEmailAddressPasswordCommand, Result<EmailAddressPassword>>
{
    private readonly IEmailAddressPasswordRepository emailAddressPasswordRepository;
    public CreateEmailAddressPasswordCommandHandler(IEmailAddressPasswordRepository emailAddressPasswordRepository)
    {
        this.emailAddressPasswordRepository = emailAddressPasswordRepository;
    }

    public async Task<Result<EmailAddressPassword>> Handle(CreateEmailAddressPasswordCommand request, CancellationToken cancellationToken)
    {
        var result = EmailAddressPassword.Create(request.EmailAddress, request.Password);

        if(!result.IsFailure) await emailAddressPasswordRepository.InsertAsync(result.Value);

        return result;
    }
}
