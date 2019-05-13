using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public static TDestination Map<TSource, TDestination>(
            this TDestination destination, TSource source)
        {
            return Mapper.Map(source, destination);
        }
        public static float TryFloat(this string source)
        {
            float result = 0;
            float.TryParse(source, out result);
            return result;
        }
    }
}
