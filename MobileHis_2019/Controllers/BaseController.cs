﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using ValidationDictionary;

namespace MobileHis_2019.Controllers
{
    public class BaseController : Controller
    {

        public class ModelStateWrapper : IValidationDictionary
        {
            public ModelStateWrapper(ModelStateDictionary modelStateDictionary)
            {
                modelState = modelStateDictionary;
            }
            private ModelStateDictionary modelState { get; set; }
            public void AddGeneralError(string errorMessage)
            {
                modelState.AddModelError(string.Empty, errorMessage);
            }
            public void AddPropertyError<TModel>(
                Expression<Func<TModel, object>> expression, 
                string errorMessage)
            {
                if (expression == null)
                {
                    throw new ArgumentNullException("method");
                }
                modelState.AddModelError(ExpressionHelper.GetExpressionText(expression), errorMessage);
            }

            public bool Any()
            {
                return modelState.Any();
            }

            public bool IsValid()
            {
                return modelState.IsValid;
            }
        }
    }
}