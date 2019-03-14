using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationDictionary
{

    [Serializable]
    public class DatebaseValidationErrros : Exception
    {
        public DatebaseValidationErrros() { }
        public DatebaseValidationErrros(string message) : base(message) { }
        public DatebaseValidationErrros(string message, Exception inner) : base(message, inner) { }
        protected DatebaseValidationErrros(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
