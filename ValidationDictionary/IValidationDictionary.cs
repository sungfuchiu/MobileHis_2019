using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationDictionary
{
    public interface IValidationDictionary
    {
        void AddPropertyError(string key, string errorMessage);
        void AddGeneralError(string errorMessage);
        bool IsValid();
        bool Any();
    }
}
