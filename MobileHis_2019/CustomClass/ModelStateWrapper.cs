using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using ValidationDictionary;

namespace MobileHis_2019.CustomClass
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
        public void AddPropertyError(string key, string errorMessage)
        {
            modelState.AddModelError(key, errorMessage);
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