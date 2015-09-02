using System.Web.Http.Filters;
using NLog;

namespace ReservationWebApi
{
	public abstract class BaseExceptionFilterAttribute : ExceptionFilterAttribute
	{
		protected static Logger Logger => LogManager.GetCurrentClassLogger();
	}
}