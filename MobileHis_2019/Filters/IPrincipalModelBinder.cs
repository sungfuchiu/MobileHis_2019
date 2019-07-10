using Autofac.Integration.Mvc;
using MobileHis.Models.Areas.Sys.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace MobileHis_2019.Filters
{
    //可以在action的地方綁定身分，不過感覺沒甚麼用，因為我用autoFac已經實現注入所有IPrincipal的功能
    //public class IPrincipalModelBinder : IModelBinder
    //{
    //    public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
    //    {
    //        if(controllerContext == null)
    //        {
    //            throw new ArgumentException("controllerContext");
    //        }
    //        if(bindingContext == null)
    //        {
    //            throw new ArgumentException("bindingContext");
    //        }
    //        IPrincipal user = controllerContext.HttpContext.User;
    //        return user;
    //    }
    //}
    //[ModelBinderType(typeof(EducationModel))]
    //public class IPrincipalModelBinder : IModelBinder
    //{
    //    public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
    //    {
    //        var educationModel = DependencyResolver.Current.GetService<EducationModel>();
    //        if (controllerContext == null)
    //        {
    //            throw new ArgumentException("controllerContext");
    //        }
    //        if (bindingContext == null)
    //        {
    //            throw new ArgumentException("bindingContext");
    //        }
    //        return educationModel;
    //    }
    //}
    //public class CollectionNotEmptyModelBinder : DefaultModelBinder
    //{
    //    protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
    //    {
    //        base.CreateModel(controllerContext, bindingContext, modelType);
    //        var model = base.CreateModel(controllerContext, bindingContext, modelType);

    //        if (model == null || model is IEnumerable)
    //            return model;

    //        foreach (var property in modelType.GetProperties(BindingFlags.Public | BindingFlags.Instance))
    //        {
    //            object value = property.GetValue(model);
    //            if (value != null)
    //                continue;

    //            if (property.PropertyType.IsArray)
    //            {
    //                value = Array.CreateInstance(property.PropertyType.GetElementType(), 0);
    //                property.SetValue(model, value);
    //            }
    //            else if (property.PropertyType.IsGenericType)
    //            {
    //                Type typeToCreate;
    //                Type genericTypeDefinition = property.PropertyType.GetGenericTypeDefinition();
    //                if (genericTypeDefinition == typeof(IDictionary<,>))
    //                {
    //                    typeToCreate = typeof(Dictionary<,>).MakeGenericType(property.PropertyType.GetGenericArguments());
    //                }
    //                else if (genericTypeDefinition == typeof(IEnumerable<>) ||
    //                         genericTypeDefinition == typeof(ICollection<>) ||
    //                         genericTypeDefinition == typeof(IList<>))
    //                {
    //                    typeToCreate = typeof(List<>).MakeGenericType(property.PropertyType.GetGenericArguments());
    //                }
    //                else
    //                {
    //                    continue;
    //                }

    //                value = Activator.CreateInstance(typeToCreate);
    //                property.SetValue(model, value);
    //            }
    //        }

    //        return model;
    //    }
    //}
}