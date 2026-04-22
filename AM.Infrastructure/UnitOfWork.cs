using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AM.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AMContext _context;
        private readonly Dictionary<Type, object> _repositories;
        private bool _disposed = false;

        /// <summary>
        /// Constructeur : initialise le contexte et le dictionnaire des repositories
        /// </summary>
        public UnitOfWork()
        {
            _context = new AMContext();
            _repositories = new Dictionary<Type, object>();
        }

        /// <summary>
        /// Obtient ou crée un repository pour une entité (DbContext.Set)
        /// </summary>
        public IGenericRepository<T> Repository<T>() where T : class
        {
            var type = typeof(T);

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>).MakeGenericType(type);
                var dbSet = _context.Set<T>();
                var repositoryInstance = Activator.CreateInstance(repositoryType, dbSet);
                _repositories.Add(type, repositoryInstance);
            }

            return (IGenericRepository<T>)_repositories[type];
        }

        /// <summary>
        /// Sauvegarde tous les changements
        /// </summary>
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// Sauvegarde tous les changements de manière asynchrone
        /// </summary>
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Libère les ressources (pattern Disposable)
        /// Protection contre les libérations multiples et libération du contexte
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Pattern Disposable avec protection contre les libérations multiples
        /// Libère le contexte qui implémente l'interface IDisposable
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Libère les ressources internes qui implémentent IDisposable
                    _context?.Dispose();
                }

                _disposed = true;
            }
        }

        /// <summary>
        /// Destructeur pour assurer la libération des ressources
        /// </summary>
        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
