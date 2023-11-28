using Resunet.BL;
using Resunet.DAL;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddMvc();
builder.Services.AddSingleton<IAuthUserDAL,AuthUserDAL>();
builder.Services.AddScoped<IAuthBL,AuthBL>();
builder.Services.AddSingleton<IEncrypt,Encrypt>();
builder.Services.AddScoped<ICurrentUser,CurrentUser>();
builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
builder.Services.AddSingleton<IDbSessionDAL,DbSessionDAL>();
builder.Services.AddScoped<IDbSession,DbSession>();


var app = builder.Build();
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}");

app.Run();