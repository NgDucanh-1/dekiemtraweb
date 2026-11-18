using Microsoft.EntityFrameworkCore;
using NguyenDucAnh_241224466.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(options =>
{
    options.ModelBindingMessageProvider.SetValueMustBeANumberAccessor(
        field => "Giá phải là số");
    options.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor(
        (value, field) => $"Giá trị '{value}' không hợp lệ");
});

builder.Services.AddDbContext<QLNhaSachContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("QLNhaSach")));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
