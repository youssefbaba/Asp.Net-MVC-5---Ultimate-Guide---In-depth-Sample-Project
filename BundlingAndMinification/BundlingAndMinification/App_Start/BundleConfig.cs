using System.Web.Optimization;

namespace BundlingAndMinification
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new StyleBundle("~/bundles/StylesBundle1").Include(
                        "~/Content/Css/Style1.css",
                        "~/Content/Css/Style2.css",
                        "~/Content/Css/Style3.css",
                        "~/Content/Css/Style4.css",
                        "~/Content/Css/Style5.css"
                        ));
            bundles.Add(new StyleBundle("~/bundles/StylesBundle2").Include(
                        "~/Content/Css/Style6.css",
                        "~/Content/Css/Style7.css",
                        "~/Content/Css/Style8.css",
                        "~/Content/Css/Style9.css",
                        "~/Content/Css/Style10.css"
                        ));


            bundles.Add(new ScriptBundle("~/bundles/ScriptsBundle1").Include(
                        "~/Scripts/Script1.js",
                        "~/Scripts/Script2.js",
                        "~/Scripts/Script3.js",
                        "~/Scripts/Script4.js",
                        "~/Scripts/Script5.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/ScriptsBundle2").Include(
                        "~/Scripts/Script6.js",
                        "~/Scripts/Script7.js",
                        "~/Scripts/Script8.js",
                        "~/Scripts/Script9.js",
                        "~/Scripts/Script10.js"
                        ));
            BundleTable.EnableOptimizations = true;

        }
    }
}