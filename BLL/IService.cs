using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IService<T> where T : class
    {
        /// <summary>
        /// 取得符合條件的Entitiy並轉成對應的ViewModel
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <param name="wherePredicate"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        List<TViewModel> GetListToViewModel<TViewModel>(
            Expression<Func<T, bool>> wherePredicate, 
            params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// 取得某條件下的某一筆Entity並轉成ViewModel
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <param name="wherePredicate"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        TViewModel GetSpecificDetailToViewModel<TViewModel>(
            Expression<Func<T, bool>> wherePredicate, 
            params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// 將ViewModel產生對應的Entity並新增到資料庫
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <param name="viewModel"></param>
        void CreateViewModelToDatabase<TViewModel>(TViewModel viewModel);

        /// <summary>
        /// 將ViewModel更新對應的Entity
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <param name="viewModel"></param>
        /// <param name="wherePredicate"></param>
        void UpdateViewModelToDatabase<TViewModel>(
            TViewModel viewModel, 
            Expression<Func<T, bool>> wherePredicate);

        /// <summary>
        /// 刪除一筆Entity
        /// </summary>
        /// <param name="wherePredicate"></param>
        void Delete(Expression<Func<T, bool>> wherePredicate);
    }
}
