using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MobileHis.Data
{
    public partial class OpdRegister
    {
        private static Dictionary<OpdStatusEnum, string> OPDStatusMapping = new Dictionary<OpdStatusEnum, string>()
        {
            {OpdStatusEnum.Waitting, "W"},
            {OpdStatusEnum.Finished, "F"},
            {OpdStatusEnum.Transfer, "T"},
            {OpdStatusEnum.Canceled, "C"},
            {OpdStatusEnum.Inspecting, "I"},
            {OpdStatusEnum.Examining, "E"}
        };
        [NotMapped]
        public OpdStatusEnum OPDStatus
        {
            get
            {
                var keys = OPDStatusMapping.Where(p => p.Value == OpdStatus).Select(p => p.Key);
                return keys.Any() ? keys.First() : OpdStatusEnum.Waitting;
            }
            set
            {
                var val = OPDStatusMapping.Where(p => p.Key == value).Select(p => p.Value).FirstOrDefault();
                OpdStatus = val == null ? "W" : val;
            }
        }

        public static string GetOpdStatus(OpdStatusEnum s)
        {
            string val;
            return OPDStatusMapping.TryGetValue(s, out val) ? val : "";
        }

    }
}