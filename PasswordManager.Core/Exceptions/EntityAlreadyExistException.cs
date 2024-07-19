namespace PasswordManager.Core;

public class EntityAlreadyExistException : Exception
{
    public EntityAlreadyExistException(int id) : base($"Entity with Id {id} is alreadyExist")
    {

    }
}
