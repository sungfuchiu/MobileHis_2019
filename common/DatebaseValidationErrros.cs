using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{

    [Serializable]
    public class DatabaseValidationErrros : Exception
    {
        //IEnumerable<System.Data.Entity.Validation.DbEntityValidationResult> _errors { get; set; }
        //public DatabaseValidationErrros(IEnumerable<System.Data.Entity.Validation.DbEntityValidationResult> errors)
        //{
        //    _errors = errors;
        //}
        public DatabaseValidationErrros(string message) : base(message) { }
        public DatabaseValidationErrros(string message, Exception inner) : base(message, inner) { }
        protected DatabaseValidationErrros(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
