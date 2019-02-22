using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Validation
{
    public interface IValidationDictionary
    {
        void AddError(string property, string errorMSG);
        bool IsValid { get; }
    }
}
