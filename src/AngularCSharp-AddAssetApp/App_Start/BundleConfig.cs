using System.Web.Optimization;

namespace AngularCSharp_AddAssetApp.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/angular.js",
                        "~/Scripts/angular-touch.js",
                        "~/Scripts/angular-animate.js",
                        "~/Scripts/angular-messages.js",
                        "~/Scripts/angular-ui/ui-bootstrap.js",
                        "~/Scripts/angular-ui/ui-bootstrap-tpls.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/angularApp").IncludeDirectory(
                        "~/AngularApp/", "*.js", true));

            bundles.Add(new ScriptBundle("~/bundles/angularGrid").Include(
                        "~/Scripts/ui-grid.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));


            bundles.Add(new StyleBundle("~/Content/allCustomCss").Include(
                      "~/Scripts/angular-csp.css",
                      "~/Content/asset-index.css",
                      "~/Content/ui-grid.css"));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = false;
        }
    }
}