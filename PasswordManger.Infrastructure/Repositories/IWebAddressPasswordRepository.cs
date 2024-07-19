using PasswordManager.Core;

namespace PasswordManager.Infrastructure;

public interface IWebAddressPasswordRepository
{
    Task Insert(WebAddressPassword entity);

    Task Delete(int id);

    Task<WebAddressPassword> GetById(int id);

    IQueryable<WebAddressPassword> GetAll();
}
