using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace Common
{
    public static class ExtensionMethod
    {
        public static bool IsNullOrEmpty(this string item)
        {
            return string.IsNullOrEmpty(item);
        }
        public static SelectList ToSelectList<TEnum>(this TEnum enumObj)
        where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            var values = from TEnum e in Enum.GetValues(typeof(TEnum))
                         select new { Id = e.ToString(), Name = e.ToString() };
            return new SelectList(values, "Id", "Name", enumObj);
        }

        public static TDestination MapFrom<TSoruce, TDestination>(this TSoruce model)
        {
            var settingConfig = new MapperConfiguration(
                cfg => cfg.CreateMap<TSoruce, TDestination>());
            var settingMapper = settingConfig.CreateMapper();
            return settingMapper.Map<TDestination>(model);
        }
        public static void MapTo<TSoruce, TDestination>(this TSoruce model, out TDestination destination)
        {
            var settingConfig = new MapperConfiguration(
                cfg => cfg.CreateMap<TSoruce, TDestination>());
            var settingMapper = settingConfig.CreateMapper();
            destination = settingMapper.Map<TDestination>(model);
        }
        public static void MapTo<TSoruce, TDestination>(this TSoruce model, TDestination entity)
        {
            var settingConfig = new MapperConfiguration(
                cfg => cfg.CreateMap<TSoruce, TDestination>());
            var settingMapper = settingConfig.CreateMapper();
            settingMapper.Map(model, entity);
        }
        /// <summary>
        /// 把目前的Model透過AutoMapper轉成某一個Type的Model。
        /// AutoMapper需要先註冊過這個轉換的設定。
        /// </summary>
        /// <typeparam name="TDestination">要轉換成的Type</typeparam>
        /// <param name="source">要被轉換的object</param>
        /// <returns>轉換成為Type的Object</returns>
        public static TDestination ToModel<TDestination>(this object source)
        {
            return AutoMapper.Mapper.Map<TDestination>(source);
        }
        public static float TryFloat(this string source)
        {
            float result = 0;
            float.TryParse(source, out result);
            return result;
        }
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, bool>> whereClause)
        {
            if (condition)
            {
                return query.Where(whereClause);
            }
            return query;
        }
        public static bool HasValue<T>(this T item)
        {
            return item != null;
        }
        public static IEnumerable<T> OrEmptyIfNull<T>(this IEnumerable<T> source)
        {
            return source ?? Enumerable.Empty<T>();
        }
    }
}
