var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapGet("/hello", (HttpContext httpContext) =>
{
    httpContext.Response.Redirect("/Home/Index");
});

app.MapGet("/goodbye", (HttpContext httpContext) =>
{
    httpContext.Response.Redirect(httpContext.Request.Scheme + Uri.SchemeDelimiter + httpContext.Request.Host + httpContext.Request.PathBase + "/Home/Index");
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
