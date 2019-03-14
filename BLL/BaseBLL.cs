using DAL.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationDictionary;

namespace BLL
{
    public class BaseBLL<T> : IBLL<T> where T : class
    {
        public ValidationDictionary.IValidationDictionary ValidationDictionary { get; private set; }
        public void InitialiseIValidationDictionary(
            ValidationDictionary.IValidationDictionary iValidationDictionary)
        {
            ValidationDictionary = iValidationDictionary;
        }

    }
}
