using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PasswordManager.Core;

public class BaseEntity<T>
{
    public T? Id { get; set; }
}
