namespace agro_shop.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}