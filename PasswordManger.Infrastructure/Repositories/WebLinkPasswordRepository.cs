using Microsoft.EntityFrameworkCore;
using PasswordManager.Core;

namespace PasswordManager.Infrastructure;

public class WebLinkPasswordRepository : IWebLinkPasswordRepository
{
    private readonly PasswordManagerDbContext _context;
    public WebLinkPasswordRepository(PasswordManagerDbContext context)
    {
        _context = context;
    }

    public async Task Delete(int id)
    {
        var entity = await _context.WebLinkPasswords.FirstOrDefaultAsync(e => e.Id == id);
        _context.WebLinkPasswords.Remove(entity ?? throw new EntityDoesNotExistException(id));
        await _context.SaveChangesAsync();
    }

    public IQueryable<WebLinkPassword> GetAll()
    {
        return _context.Set<WebLinkPassword>();
    }

    public async Task<WebLinkPassword?> GetById(int id)
    {
        return await _context.WebLinkPasswords.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task Insert(WebLinkPassword entity)
    {
        var existing = await _context.WebLinkPasswords.FindAsync(entity);
        if(existing != null) throw new EntityAlreadyExistException(entity.Id);
        _context.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(WebLinkPassword entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
    }
}
