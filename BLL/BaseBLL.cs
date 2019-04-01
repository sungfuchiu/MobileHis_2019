using DAL.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BaseBLL<T> : IBLL<T> where T : class
    {
        public Common.IValidationDictionary ValidationDictionary { get; private set; }
        public void InitialiseIValidationDictionary(
            Common.IValidationDictionary iValidationDictionary)
        {
            ValidationDictionary = iValidationDictionary;
        }

    }
}
