using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesMovie.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<RazorPagesMovieContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("RazorPagesMovieContext") ?? throw new InvalidOperationException("Connection string 'RazorPagesMovieContext' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

//添加自定义静态文件路径
//app.UseStaticFiles(new StaticFileOptions() {
//    FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "文件夹名")),
//    RequestPath = "/请求路径"
//});

//添加静态文件本地缓存 一周内公开可用
//app.UseStaticFiles(new StaticFileOptions()
//{
//    OnPrepareResponse = (ctx) =>
//    {
//        ctx.Context.Response.Headers.Append("Cache-Control", $"public, max-age={(60 * 60 * 24 * 7)}");
//    }
//});

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
