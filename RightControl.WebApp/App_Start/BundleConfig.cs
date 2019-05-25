using System.Web.Optimization;

namespace RightControl.WebApp
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            

            BundleTable.EnableOptimizations = true;
        }
    }
}
