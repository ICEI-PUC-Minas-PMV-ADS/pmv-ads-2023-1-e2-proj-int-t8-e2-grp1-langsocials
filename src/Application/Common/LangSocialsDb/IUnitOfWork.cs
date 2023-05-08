namespace Application.Common.LangSocialsDb;

public interface IUnitOfWork
{
    Task SaveChagnes(CancellationToken cancellationToken = default);
}
