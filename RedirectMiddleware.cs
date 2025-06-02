using System.Net.Mime;
using Microsoft.Net.Http.Headers;

public class RedirectMiddleware
{
    private readonly RequestDelegate _next;

    public RedirectMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        await _next(context);

        if (context.Response.StatusCode == StatusCodes.Status302Found || context.Response.StatusCode == StatusCodes.Status301MovedPermanently)
        {
            if (Uri.TryCreate(context.Response.Headers[HeaderNames.Location], UriKind.Absolute, out var location))
            {
                if (location.Scheme == context.Request.Scheme && new HostString(location.Host, location.Port) == context.Request.Host)
                {
                    context.Response.Redirect(location.PathAndQuery, context.Response.StatusCode == StatusCodes.Status301MovedPermanently);
                }
            }
        }
    }
}