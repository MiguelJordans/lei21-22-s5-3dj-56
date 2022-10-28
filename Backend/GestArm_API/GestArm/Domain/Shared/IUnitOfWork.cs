namespace GestArm.Domain.Shared;

public interface IUnitOfWork
{
    Task<int> CommitAsync();
}