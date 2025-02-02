using Microsoft.EntityFrameworkCore;
using MusicLib.BLL.Interfaces;
using MusicLib.BLL.Services;
using MusicLib.BLL.Infrastructure;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;


// Microsoft.EntityFrameworkCore.Design пакет необходим для миграций
var builder = WebApplication.CreateBuilder(args);


// <snippet_LocalizationConfigurationServices>
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddMvc()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();
// </snippet_LocalizationConfigurationServices>


// <snippet_RequestLocalizationOptionsConfiguration>
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[] { "en-US", "uk-UA" };
    options.SetDefaultCulture(supportedCultures[0])
        .AddSupportedCultures(supportedCultures)
        .AddSupportedUICultures(supportedCultures);
});
// </snippet_RequestLocalizationOptionsConfiguration>

// Все сессии работают поверх объекта IDistributedCache, и 
// ASP.NET Core предоставляет встроенную реализацию IDistributedCache
builder.Services.AddDistributedMemoryCache();// добавляем IDistributedMemoryCache
builder.Services.AddSession();  // Добавляем сервисы сессии

// Получаем строку подключения из файла конфигурации
string? connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddMusicLibContext(connection);
builder.Services.AddUnitOfWorkService();
builder.Services.AddTransient<IRoleService, RoleService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IVideoService, VideoService>();
builder.Services.AddTransient<IArtistService, ArtistService>();
builder.Services.AddTransient<IGenreService, GenreService>();
builder.Services.AddTransient<ISongService, SongService>();

// Добавляем сервисы MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();
app.UseSession();   // Добавляем middleware-компонент для работы с сессиями
app.UseStaticFiles(); // обрабатывает запросы к файлам в папке wwwroot

// <snippet_ConfigureLocalization>
var localizationOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(localizationOptions.Value);
// </snippet_ConfigureLocalization>

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
});
app.Run();
