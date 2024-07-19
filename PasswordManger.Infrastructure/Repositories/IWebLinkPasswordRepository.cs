using PasswordManager.Core;

namespace PasswordManager.Infrastructure;

public interface IWebLinkPasswordRepository
{
    Task Insert(WebLinkPassword entity);

    Task Delete(int id);

    Task<WebLinkPassword> GetById(int id);

    IQueryable<WebLinkPassword> GetAll();
}
