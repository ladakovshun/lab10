using WebApplication10.Services;

var builder = WebApplication.CreateBuilder(args);

// Реєстрація сервісу для валідації консультацій
builder.Services.AddScoped<IConsultationService, ConsultationService>();

// Додаємо MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
