using System.ComponentModel.DataAnnotations;
using CSharpFunctionalExtensions;
using MediatR;
using PasswordManager.Core;

namespace Contracts;

public record class CreateEmailAddressPasswordCommand : IRequest<Result<EmailAddressPassword>> {
    [Required] public string EmailAddress { get; set; }

    [Required] public string Password { get; set;}
}
