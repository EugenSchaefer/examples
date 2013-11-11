using System.Web.Optimization;

namespace Allfacebook.SPA.Example
{
    public class BundleConfig
    {
        // Weitere Informationen zu Bundling finden Sie unter "http://go.microsoft.com/fwlink/?LinkId=254725".
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/files/scripts")
                            .Include("~/Scripts/jquery/jquery-{version}.js")
                            .Include("~/Scripts/bootstrap/bootstrap.js")
                            .Include("~/Scripts/angular/angular.js")
                            .Include("~/Scripts/angular/angular-cookies.js")
                            //.Include("~/Scripts/angular-strap/angular-strap.js")
                            .Include("~/Scripts/angular/angular-bootstrap.js")
                            //.Include("~/Scripts/angular-strap/directives/typeahead.js")
                            .Include("~/Scripts/angular_ui/ui-bootstrap-{version}.js")
                            //.Include("~/Scripts/angular-strap/vendor/bootstrap-datepicker.js")
                            //.Include("~/Scripts/angular-strap/vendor/bootstrap-select.js")
                            //.Include("~/Scripts/angular-strap/vendor/bootstrap-timepicker.js")
                            //.Include("~/Scripts/angular-file-upload/angular-file-upload.js")
                            .Include("~/Scripts/angular/angular-sanitize.js")
                );

            // CSS Bundles
            bundles.Add(new Bundle("~/Content/files/css-third-party")
                            .Include("~/Content/bootstrap/bootstrap.css")
                            .Include("~/Content/bootstrap/bootstrap-responsive.css")
                            .Include("~/Content/auth-buttons.css")
                );

            bundles.Add(new Bundle("~/Content/files/css-app")
                            .Include("~/Content/main.css"));

            AddShellScripts(bundles);
            AddMessagesScripts(bundles);
            AddDashboardScripts(bundles);
            AddLoginScripts(bundles);
        }

        public static void AddShellScripts(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/files/scripts/shell")
                            .Include("~/WebApp/app/scripts/app.js")
                            .Include("~/WebApp/app/shell/shellCtrl.js"));
        }

        public static void AddMessagesScripts(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/files/scripts/messages")
                            .Include("~/WebApp/app/messages/messagesCtrl.js"));
        }

        public static void AddDashboardScripts(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/files/scripts/dashboard")
                            .Include("~/WebApp/app/dashboard/dashboardCtrl.js"));
        }
        public static void AddLoginScripts(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/files/scripts/login")
                            .Include("~/WebApp/app/login/loginCtrl.js"));
        }
    }
}