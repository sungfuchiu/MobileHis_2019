using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ValidationDictionary
{
    public interface IValidationDictionary
    {
        //void AddPropertyError(string key, string errorMessage);
        void AddPropertyError<TModel>(
                Expression<Func<TModel, object>> method,
                string message);
        void AddGeneralError(string errorMessage);
        bool IsValid();
        bool Any();
    }
}
