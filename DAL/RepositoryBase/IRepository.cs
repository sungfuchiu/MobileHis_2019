using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRepository<T>
    {
        /// <summary>
        /// 新增一筆
        /// </summary>
        /// <param name="entity"></param>
        void Create(T entity);
        /// <summary>
        /// 取得符合條件的第一筆
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        T Read(Expression<Func<T, bool>> predicate);
        T ReadWithNoTracking(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// 取得Entity全部的IQueryable
        /// </summary>
        /// <returns></returns>
        IQueryable<T> Reads();
        /// <summary>
        /// 更新內容
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);
        /// <summary>
        /// 更新指定的Property
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="updateProperties"></param>
        void Update(T entity, Expression<Func<T, object>>[] updateProperties);
        /// <summary>
        /// 刪一筆資料
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);
        /// <summary>
        /// 儲存異動
        /// </summary>
        void SaveChanges();
    }
}
