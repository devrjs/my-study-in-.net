using NSE.Core.DomainObjects;

namespace NSE.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
