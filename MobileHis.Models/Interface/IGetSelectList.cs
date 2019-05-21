﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis.Models.Interface
{
    public delegate List<System.Web.Mvc.SelectListItem> GetSelectList(string itemType = "", string selectedValue = "", bool hasEmpty = false);
    interface IGetSelectList
    {
        event GetSelectList SelectListEvent;
    }
    //public abstract class SelectList : IGetSelectList
    //{
    //    public event GetSelectList SelectListEvent;
    //    public SelectList(GetSelectList selectListEvent)
    //    {
    //        SelectListEvent = selectListEvent;
    //    }
    //}
}
