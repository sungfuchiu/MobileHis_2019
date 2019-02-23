using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileHis.Models
{
    public class EntityPagingModel<TEntity, TFilter>
        where TFilter : IPageFilter
    {
        public EntityPagingModel(IOrderedQueryable<TEntity> query, TFilter filter, int pageSize = 15)
        {
            int page = 0;
            if (filter != null) page = filter.p;

            if (query != null)
            {
                int TotalPages = (int)Math.Ceiling(query.Count() / (decimal)pageSize);
                if (filter.p >= TotalPages) filter.p = 0;

                Filter = filter;

                int start = page * pageSize,
                    end = start + pageSize;


                Entries = query.Skip(start).Take(pageSize);

                Paging = new PageIndexModel()
                {
                    CurrentPage = filter.p,
                    PagingSize = pageSize,
                    TotalPages = TotalPages,
                    TotalRecords = query.Count(),
                    CurrentRecordRange = new Tuple<int, int>(start, end)
                };
            }
        }

        /// <summary>
        /// 資料搜尋表單
        /// </summary>
        public TFilter Filter { get; set; }

        /// <summary>
        /// 資料
        /// </summary>
        public IEnumerable<TEntity> Entries { get; set; }

        /// <summary>
        /// 分頁資訊
        /// </summary>
        public PageIndexModel Paging { get; private set; }
    }

    public interface IPageFilter
    {
        /// <summary>
        /// Current page number, start from 0
        /// </summary>
        int p { get; set; }
    }

    public interface ISortableFilter<TEntity> : IPageFilter
    {
        IOrderedQueryable<TEntity> Sort(IQueryable<TEntity> query);
    }

    public interface IFilterableFilter<TEntity> : IPageFilter
    {
        IQueryable<TEntity> Filter(IQueryable<TEntity> query);

    }

    public class PageIndexModel
    {
        public int PagingSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        public int TotalRecords { get; set; }
        public Tuple<int, int> CurrentRecordRange { get; set; }
    }

    public class PageFilter : IPageFilter
    {
        public int p { get; set; }
    }
}