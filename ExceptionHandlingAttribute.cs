using System.Web.Http.Filters;
using Newtonsoft.Json;

namespace ReservationWebApi
{
	public class ExceptionHandlingAttribute : BaseExceptionFilterAttribute
	{
		public override void OnException(HttpActionExecutedContext context)
		{
			if (context.Exception != null)
			{
				Logger.Fatal("REQUEST:{0}\nEXCEPTION:{1}\n\n", context.Request, JsonConvert.SerializeObject(context.Exception.GetBaseException()));
			}
		}
	}
}