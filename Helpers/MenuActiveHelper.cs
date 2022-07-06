using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EnterpriseIMS.Helpers
{
    public static class MenuActiveHelper
    {

        public static HtmlString IsActive(this IHtmlHelper html,
                                  string control,
                                  string action)
        {
            var routeData = html.ViewContext.RouteData;

            var routeAction = (string)routeData.Values["action"];
            var routeControl = (string)routeData.Values["controller"];

            // both must match
            var returnActive = control == routeControl &&
                               action == routeAction;
            return returnActive ? new HtmlString("active") : new HtmlString("");
        }

        public static HtmlString IsMenuActive(this IHtmlHelper html,
                                  string control,
                                  string action)
        {
            var routeData = html.ViewContext.RouteData;

            var routeAction = (string)routeData.Values["action"];
            var routeControl = (string)routeData.Values["controller"];
            var returnActive = control.Contains(routeControl) &&
                               action.Contains(routeAction);
            return returnActive ? new HtmlString("active") : new HtmlString("");
        }

    }
}
