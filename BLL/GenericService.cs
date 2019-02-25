using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AutoMapper;
using System.Reflection;
using System.Web;
using System.IO;

namespace BLL
{
    public class GenericService<T> : IService<T> where T : class
    {
        protected IUnitOfWork db;
        public GenericService(IUnitOfWork unitOfWork)
        {
            db = unitOfWork;
        }

        public List<TViewModel> GetListToViewModel<TViewModel>(Expression<Func<T, bool>> wherePredicate, params Expression<Func<T, object>>[] includes)
        {
            var data = db.Repository<T>().Reads();
            foreach(var item in includes)
            {
                data.Include(item);
            }
            return AutoMapper.Mapper.Map<List<TViewModel>>(data.Where(wherePredicate));
        }
        public TViewModel GetSpecificDetailToViewModel<TViewModel>(Expression<Func<T, bool>> wherePredicate, params Expression<Func<T, object>>[] includes)
        {
            var data = db.Repository<T>().Reads();
            foreach (var item in includes)
            {
                data.Include(item);
            }
            return AutoMapper.Mapper.Map<List<TViewModel>>(data.Where(wherePredicate)).FirstOrDefault();
        }
        public void UpdateViewModelToDatabase<TViewModel>(
            TViewModel viewModel, Expression<Func<T, bool>> wherePredicate)
        {
            var entity = db.Repository<T>().Read(wherePredicate);

            AutoMapper.Mapper.Map(viewModel, entity);

            db.Repository<T>().Update(entity);

            db.Save();
        }
        public void Delete(Expression<Func<T, bool>> wherePredicate)
        {
            var data = db.Repository<T>().Read(wherePredicate);
            db.Repository<T>().Delete(data);

            db.Save();
        }
        public void CreateViewModelToDatabase<TViewModel>(TViewModel viewModel)
        {
            ProcessHttpPostFile(viewModel);

            var entity = AutoMapper.Mapper.Map<T>(viewModel);

            db.Repository<T>().Create(entity);

            db.Save();
        }
        public virtual void ProcessHttpPostFile(object viewModel)
        {
            var properties = viewModel.GetType()
                  .GetProperties(BindingFlags.Instance |
                 BindingFlags.Public | BindingFlags.FlattenHierarchy);
            var basePath = @"D:\";

            foreach (var item in properties
                .Where(x => x.PropertyType == typeof(HttpPostedFileBase)))
            {
                var httpost = item.GetValue(viewModel) as HttpPostedFileBase;

                if (httpost != null
             && string.IsNullOrEmpty(httpost.FileName) == false)
                {
                    // 如果postFile的property名稱後面一定會加File。例如：
                    //CoverImgFile對應的string property名稱就是CoverImg。
                    // 因此看看是否有property的名稱是postFile的名稱減去4（File是4個字）
                    var fileNameProperty = properties
                        .Where(x => x.Name == item.Name.Remove(item.Name.Count() - 4))
                       .FirstOrDefault();

                    if (fileNameProperty != null)
                    {
                        var savePath = Path.Combine(basePath, httpost.FileName);

                        if (Directory.Exists(Path.GetDirectoryName(savePath)) == false)
                        {
                            Directory.CreateDirectory(Path.GetDirectoryName(savePath));
                        }

                        httpost.SaveAs(savePath);

                        fileNameProperty.SetValue(viewModel, httpost.FileName);
                    }
                }
            }
        }


    }
}
