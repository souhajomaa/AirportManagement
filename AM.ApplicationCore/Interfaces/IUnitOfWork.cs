using System;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Obtient un repository pour une entité
        /// </summary>
        IGenericRepository<T> Repository<T>() where T : class;

        /// <summary>
        /// Sauvegarde tous les changements
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// Sauvegarde tous les changements de manière asynchrone
        /// </summary>
        Task SaveChangesAsync();
    }
}
