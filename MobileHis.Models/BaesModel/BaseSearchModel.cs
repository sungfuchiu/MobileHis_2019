using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis.Models
{
    public class BaseSearchModel
    {
        int? page;
        public int Page
        {
            get => page ?? 1;
            set => page = value;
        }
        public string Keyword { get; set; }
    }
    public class CheckBoxModel
    {
        public int Id { get; set; }           // Integer value of a checkbox
        public string Name { get; set; }      // String name of a checkbox
        public object Tags { get; set; }      // Object of html tags to be applied to checkbox, e.g.: 'new { tagName = "tagValue" }'
        public bool IsSelected { get; set; }  // Boolean value to select a checkbox on the list
    }
}
