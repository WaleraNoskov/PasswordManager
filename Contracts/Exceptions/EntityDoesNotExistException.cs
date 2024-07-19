namespace PasswordManager.Core;

public class EntityDoesNotExistException : Exception
{
    public EntityDoesNotExistException(int id) : base($"Enity with Id {id} does not exist")
    {

    }
}
