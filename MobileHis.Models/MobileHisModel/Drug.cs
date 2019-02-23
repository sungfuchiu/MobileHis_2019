using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileHis.Models
{
    public partial class Drug
    {
        public string ToString()
        {
            return String.Format("[{0}] {1}", this.OrderCode, this.Title);
        }
    }
}