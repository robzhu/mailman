using System.Web.UI;

namespace Mailman.Utils
{
    public static class PageExtensions
    {
        public static void RefreshSelf(this Page page)
        {
            page.Response.Redirect("~" + page.Request.Url.PathAndQuery, false);
        }
    }
}