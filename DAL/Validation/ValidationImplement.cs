using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Validation
{
    public class ValidationImplement : IValidationDictionary
    {
        private Dictionary<string, string> validationDictionary;
        public ValidationImplement(Dictionary<string, string> keyValues)
        {
            validationDictionary = keyValues;
        }

        public void AddError(string key, string errorMessage)
        {
            validationDictionary.Add(key, errorMessage);
        }
        public bool IsValid
        {
            get { return validationDictionary.Count == 0; }
        }
    }
}
