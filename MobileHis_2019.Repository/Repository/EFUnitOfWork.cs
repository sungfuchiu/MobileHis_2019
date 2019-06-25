using MobileHis.Data;
using MobileHis_2019.Repository.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis_2019.Repository
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private IPrincipal _principal;

        private bool _disposed;
        private Hashtable _repositories;

        /// <summary>
        /// 設定此Unit of work(UOF)的Context。
        /// </summary>
        /// <param name="context">設定UOF的context</param>
        public EFUnitOfWork(DbContext context, IPrincipal principal)
        {
            _context = context;
            _principal = principal;
        }

        /// <summary>
        /// 儲存所有異動。
        /// </summary>
        public void Save()
        {
            foreach (var entry in _context.ChangeTracker.Entries<IUserEntity>())
            {
                var entity = entry.Entity;
                switch (entry.State)
                {
                    case EntityState.Added:
                    case EntityState.Modified:
                        entity.ModUser = _principal.Identity.Name;
                        break;
                }
            }
            _context.SaveChanges();
        }

        /// <summary>
        /// 清除此Class的資源。
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 清除此Class的資源。
        /// </summary>
        /// <param name="disposing">是否在清理中？</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }

        /// <summary>
        /// 取得某一個Entity的Repository。
        /// 如果沒有取過，會initialise一個
        /// 如果有就取得之前initialise的那個。
        /// </summary>
        /// <typeparam name="T">此Context裡面的Entity Type</typeparam>
        /// <returns>Entity的Repository</returns>

        public IRepository<T> Repository<T>() where T : class
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);

                var repositoryInstance =
                    Activator.CreateInstance(repositoryType
                            .MakeGenericType(typeof(T)), _context);

                _repositories.Add(type, repositoryInstance);
            }

            return (IRepository<T>)_repositories[type];
        }
        //public IIDRepository<T> IDRepository<T>() where T : class, IIDEntity
        //{
        //    if (_repositories == null)
        //    {
        //        _repositories = new Hashtable();
        //    }

        //    var type = typeof(T).Name;

        //    if (!_repositories.ContainsKey(type))
        //    {
        //        var repositoryType = typeof(RepositoryBase<>);

        //        var repositoryInstance =
        //            Activator.CreateInstance(repositoryType
        //                    .MakeGenericType(typeof(T)), _context);

        //        _repositories.Add(type, repositoryInstance);
        //    }

        //    return (IIDRepository<T>)_repositories[type];
        //}
        //public IGuidRepository<T> GuidRepository<T>() where T : class, IGuidEntity
        //{
        //    if (_repositories == null)
        //    {
        //        _repositories = new Hashtable();
        //    }

        //    var type = typeof(T).Name;

        //    if (!_repositories.ContainsKey(type))
        //    {
        //        var repositoryType = typeof(RepositoryBase<>);

        //        var repositoryInstance =
        //            Activator.CreateInstance(repositoryType
        //                    .MakeGenericType(typeof(T)), _context);

        //        _repositories.Add(type, repositoryInstance);
        //    }

        //    return (IGuidRepository<T>)_repositories[type];
        //}
    }
}
