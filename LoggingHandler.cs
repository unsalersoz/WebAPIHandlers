using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ReservationWebApi
{
	public class LoggingHandler : BaseDelegatingHandler
	{
		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			Guid guid = Guid.NewGuid();
			string currentAction = request.RequestUri.AbsolutePath;

			if (request.Content != null)
			{
				Logger.Trace("{0} - {1}:{2}", guid, currentAction, await request.Content.ReadAsStringAsync().ConfigureAwait(false));
				Logger.Info("{0} - {1} is called", guid, currentAction);
			}

			HttpResponseMessage response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

			if (response.Content != null)
			{
				Logger.Trace("{0} - {1}", guid, await response.Content.ReadAsStringAsync().ConfigureAwait(false));
				Logger.Info("{0} - {1} is returning", guid, currentAction);
			}

			return response;
		}
	}
}