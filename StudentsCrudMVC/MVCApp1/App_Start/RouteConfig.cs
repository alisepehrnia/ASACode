using System.Web.Mvc;
using System.Web.Routing;

namespace MVCApp1
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				"Default",
				"{controller}/{action}/{id}",
				new { controller = "Students", action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}