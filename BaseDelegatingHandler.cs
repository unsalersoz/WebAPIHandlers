using System.Net.Http;
using NLog;

namespace ReservationWebApi
{
	public abstract class BaseDelegatingHandler : DelegatingHandler
	{
		protected static Logger Logger => LogManager.GetCurrentClassLogger();
	}
}