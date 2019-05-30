﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Common;
using MobileHis.Data;

namespace DAL
{
    public class CodeFileDAL : IDDALBase<CodeFile>
    {
        public IEnumerable<CodeFile> GetListByItemType(string itemType)
        {
            return base.GetAllWithNoTracking().Where(x => 
                x.ItemType.Equals(itemType, StringComparison.InvariantCultureIgnoreCase) 
                && x.CheckFlag != "D")
                .OrderBy(x => x.ItemCode);
        }
        public List<T> GetListByIds<T>(List<string> list, Expression<Func<CodeFile, T>> expression)
        {
            Reads();
            ContainsIn(list);
            IQueryable<T> result = Select(expression);
            return ReadsResult<T>(result).ToList();
        }
        private void ContainsIn(List<string> list)
        {
            List<int> intList = new List<int>();
            list.ForEach(a => intList.Add(int.Parse(a)));
            ContainsIn(intList);
        }
        private void ContainsIn(List<int> list)
        {
            Entity = Entity.Where(a => list.Contains(a.ID));
        }

        /// <summary>
        /// 顯示清單
        /// </summary>
        /// <param name="currentPageIndex"></param>
        /// <returns></returns>
        public List<CodeFile> GetList(string itemType = "", string keyword = "")
        {
            Reads(a => a.Parent);
            var data = Entity.Where(x => x.CheckFlag != "D")
                .OrderBy(x => x.ItemType)
                .ThenBy(x => x.ItemDescription)
                .Select(x => x);
            if (!itemType.IsNullOrEmpty())
                data = data.Where(x => x.ItemType.Equals(itemType));
            if (!keyword.IsNullOrEmpty())
                data = data.Where(x => x.ItemDescription.Contains(keyword)
                        || x.Remark.Contains(keyword)
                        || x.ItemCode.Contains(keyword)
                    );
            return data.OrderBy(x => x.ID).ToList();
        }

        
    }
}