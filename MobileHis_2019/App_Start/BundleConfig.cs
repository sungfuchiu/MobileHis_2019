using System.Web;
using System.Web.Optimization;

namespace MobileHis_2019
{
    public class BundleConfig
    {
        // 如需統合的詳細資訊，請瀏覽 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 使用開發版本的 Modernizr 進行開發並學習。然後，當您
            // 準備好可進行生產時，請使用 https://modernizr.com 的建置工具，只挑選您需要的測試。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new ScriptBundle("~/bundles/JSForAce").Include(
                "~/Content/assets/js/ace-elements.min.js",
                "~/Content/assets/js/ace.min.js",
                "~/Content/assets/js/date-time/moment.min.js",
                "~/Content/assets/js/date-time/bootstrap-datetimepicker.min.js",
                "~/Content/assets/js/chosen.jquery.min.js"
            ));

            bundles.Add(new StyleBundle("~/Content/cssForAce").Include(
                "~/Content/assets/css/bootstrap.min.css",
                "~/Content/assets/css/chosen.css",
                "~/Content/assets/css/ace.css",
                "~/Content/assets/css/bootstrap-datetimepicker.css"
                ));
            bundles.Add(new StyleBundle("~/Content/Font-Awesome").Include(
                "~/Content/assets/css/font-awesome.min.css",
                "~/Content/assets/css/ace-fonts.css"
                ));
        }
    }
}
