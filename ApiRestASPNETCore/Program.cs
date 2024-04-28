using Microsoft.EntityFrameworkCore; // para usar el dbcontext
using ApiRestASPNETCore.Data;

var builder = WebApplication.CreateBuilder(args); // se crea la aplicacion

// Add services to the container.

builder.Services.AddControllers(); //puede ser este tamb
//builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Conexiones>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL"));
}
    );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build(); // se construye la app

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

}
else {
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
 
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Vestimenta}/{action=GetVestimentas}");

app.Run();
