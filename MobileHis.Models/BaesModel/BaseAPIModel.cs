using MobileHis.Models.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace MobileHis.Models
{
    public class BaseAPIModel<TEntity>
    {
        public BaseAPIModel() { }
        int? page;
        DateTime? modifiedDate;
        DateTime? createDate;
        public int Page
        {
            get => page ?? 1;
            set => page = value;
        }
        public IPagedList<TEntity> EntityPageList { get; set; }
        public string Keyword { get; set; }
        public DateTime CreateDate
        {
            get => createDate ?? DateTime.Now;
            set => createDate = value;
        }
        public DateTime ModDate
        {
            get => modifiedDate ?? DateTime.Now;
            set => modifiedDate = value;
        }
        [MaxLength(100)]
        public string ModUser { get; set; }
    }
}
