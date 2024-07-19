using PasswordManager.Core;

namespace PasswordManager.Infrastructure;

public interface IEmailAddressPasswordRepository
{
    Task InsertAsync(EmailAddressPassword entity);

    Task Delete(int id);

    Task<EmailAddressPassword> GetById(int id);

    IQueryable<EmailAddressPassword> GetAll();
}
