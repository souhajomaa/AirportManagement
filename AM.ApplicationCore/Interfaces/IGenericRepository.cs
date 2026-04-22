using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AM.ApplicationCore.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Récupère tous les éléments
        /// </summary>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Récupère les éléments avec une condition
        /// </summary>
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Recherche par clé primaire
        /// </summary>
        T GetById(params object[] id);

        /// <summary>
        /// Ajoute un élément
        /// </summary>
        void Add(T entity);

        /// <summary>
        /// Ajoute plusieurs éléments
        /// </summary>
        void AddRange(IEnumerable<T> entities);

        /// <summary>
        /// Supprime un élément
        /// </summary>
        void Delete(T entity);

        /// <summary>
        /// Supprime plusieurs éléments
        /// </summary>
        void DeleteRange(IEnumerable<T> entities);

        /// <summary>
        /// Met à jour un élément
        /// </summary>
        void Update(T entity);

        /// <summary>
        /// Vérifie si un élément existe
        /// </summary>
        bool Any(Expression<Func<T, bool>> predicate);
    }
}
