using Microsoft.EntityFrameworkCore;
using PasswordManager.Core;

namespace PasswordManager.Infrastructure;

public class WebAddressPasswordRepository : IWebAddressPasswordRepository
{
    private readonly PasswordManagerDbContext _context;
    public WebAddressPasswordRepository(PasswordManagerDbContext context)
    {
        _context = context;
    }

    public async Task Delete(int id)
    {
        var entity = await _context.WebAddressPasswords.FirstOrDefaultAsync(e => e.Id == id);
        _context.WebAddressPasswords.Remove(entity ?? throw new EntityDoesNotExistException(id));
        await _context.SaveChangesAsync();
    }

    public IQueryable<WebAddressPassword> GetAll()
    {
        return _context.Set<WebAddressPassword>();
    }

    public async Task<WebAddressPassword?> GetById(int id)
    {
        return await _context.WebAddressPasswords.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task Insert(WebAddressPassword entity)
    {
        var existing = await _context.WebLinkPasswords.FindAsync(entity);
        if(existing != null) throw new EntityAlreadyExistException(entity.Id);
        _context.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(WebAddressPassword entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
    }
}
