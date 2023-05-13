namespace Application.Common.LangSocialsDb;

public interface ILangSocialsDbUnitOfWork
{
    Task SaveChagnes(CancellationToken cancellationToken = default);
}
