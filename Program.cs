var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseForwardedHeaders();

app.UseHttpsRedirection();
app.UseRouting();

app.MapGet("/", (HttpContext httpContext) =>
{
    httpContext.Response.Redirect("/goodbye");
});

app.MapGet("/hello", (HttpContext httpContext) =>
{
    httpContext.Response.Redirect("/youdidit");
});

app.MapGet("/goodbye", (HttpContext httpContext) =>
{
    httpContext.Response.Redirect(httpContext.Request.Scheme + Uri.SchemeDelimiter + httpContext.Request.Host + httpContext.Request.PathBase + "/youdidit");
});

app.MapGet("/youdidit", () =>
{
    return "You did it!";
});

app.Run();
