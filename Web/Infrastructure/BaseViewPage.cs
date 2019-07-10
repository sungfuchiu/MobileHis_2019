using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileHis.Razor
{
    public abstract class BaseViewPage : WebViewPage
    {
        public bool _Add { get; set; }
        public bool _Delete { get; set; }
        public bool _Update { get; set; }
        public bool _Print { get; set; }
        //public virtual new CustomPrincipal User
        //{
        //    get { return base.User as CustomPrincipal; }
        //}


        protected override void InitializePage()
        {
            _Add = ViewBag._Add == null ? false : ViewBag._Add;
            _Delete = ViewBag._Delete == null ? false : ViewBag._Delete;
            _Update = ViewBag._Update == null ? false : ViewBag._Update;
            _Print = ViewBag._Print == null ? false : ViewBag._Print;
            base.InitializePage();
        }
    }
    public abstract class BaseViewPage<TModel> : WebViewPage<TModel>
    {

        public bool _Add { get; set; }
        public bool _Delete { get; set; }
        public bool _Update { get; set; }
        public bool _Print { get; set; }
        //public virtual new CustomPrincipal User
        //{
        //    get { return base.User as CustomPrincipal; }
        //}

        protected override void InitializePage()
        {
            _Add = ViewBag._Add == null ? false : ViewBag._Add;
            _Delete = ViewBag._Delete == null ? false : ViewBag._Delete;
            _Update = ViewBag._Update == null ? false : ViewBag._Update;
            _Print = ViewBag._Print == null ? false : ViewBag._Print;
            base.InitializePage();
        }
    }
}