using Microsoft.EntityFrameworkCore;
using PasswordManager.Core;

namespace PasswordManager.Infrastructure;

public class EmailAddressPasswordRepository : IEmailAddressPasswordRepository
{
    private readonly PasswordManagerDbContext _context;
    public EmailAddressPasswordRepository(PasswordManagerDbContext context)
    {
        _context = context;
    }

    public async Task Delete(int id)
    {
        var entity = await _context.WebAddressPasswords.FirstOrDefaultAsync(e => e.Id == id);
        _context.WebAddressPasswords.Remove(entity ?? throw new EntityDoesNotExistException(id));
        await _context.SaveChangesAsync();
    }

    public IQueryable<EmailAddressPassword> GetAll()
    {
        return _context.Set<EmailAddressPassword>();
    }

    public async Task<EmailAddressPassword?> GetById(int id)
    {
        return await _context.WebAddressPasswords.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task InsertAsync(EmailAddressPassword entity)
    {
        _context.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(EmailAddressPassword entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
    }
}
