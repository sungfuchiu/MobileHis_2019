using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileHis.Models
{
    public class JwtModel
    {
        int _nAccId, _nExpireMin;
        string _sUserName, _iss, _aud;
        double _exp, _nbf;
        /// <summary>
        /// account.id
        /// </summary>
        public int AccId { get {return _nAccId;} set {_nAccId = value;} }
        public int ExpireMin { get {return _nExpireMin;} set { _nExpireMin = value; } }
        public string UserName { get  {return _sUserName;} set { _sUserName = value; } }

        /// <summary>
        /// identifies principal that issued the JWT
        /// </summary>
        public string iss { get {return _iss;} set {_iss = value; } }
        /// <summary>
        /// The "aud" (audience) claim identifies the recipients that the JWT is intended for.
        /// Each principal intended to process the JWT MUST identify itself with a value in the audience claim.
        /// If the principal processing the claim does not identify itself with a value 
        /// in the aud claim when this claim is present, then the JWT MUST be rejected
        /// </summary>
        public string aud { get  {return _aud; } set { _aud = value; } }

        /// <summary>
        /// expire datetime
        /// </summary>
        public double exp { get  {return _exp; } set { _exp = value; } }
        /// <summary>
        /// not before
        /// </summary>
        public double nbf { get { return _nbf; } set { _nbf = value; } }
    }
    public enum JWTStatus
    {
        Valid, Timeout, Invalid
    }
}
