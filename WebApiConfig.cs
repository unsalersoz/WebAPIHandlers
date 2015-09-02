using System.Net.Http.Formatting;
using System.Web.Http;

namespace ReservationWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{action}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);

            config.Routes.MapHttpRoute(
                name: "DefaultApi2",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

			//Formatters
			config.Formatters.Clear();
			config.Formatters.Add(new JsonMediaTypeFormatter());

			//Filters
			config.Filters.Add(new ExceptionHandlingAttribute());
			
			//MessageHandlers
			config.MessageHandlers.Add(new LoggingHandler());
		}
    }
}
