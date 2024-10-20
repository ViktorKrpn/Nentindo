using Microsoft.EntityFrameworkCore;
using Nentindo.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Nentindo.Services.Auth;
using Nentindo.Services.Contacts;
using Nentindo.Services.Articles;

//https://localhost:7229/
public class AppStart()
{
    public static void Main()
    {
        var builder = WebApplication.CreateBuilder();
        //builder.WebHost.UseUrls(new[] { "https://localhost:7229" });
        builder.Services.AddControllersWithViews();

        builder.Services.AddDbContext<DatabaseContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("SqlDatabase")));

        var connectionString = builder.Configuration.GetConnectionString("SqlDatabase");

        Console.WriteLine($"The SQL connection string is {connectionString}");

        builder.Services.AddAuthorization();

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen();

        var jwtIssuer = builder.Configuration.GetSection("Jwt:Issuer").Get<string>();
        var jwtKey = builder.Configuration.GetSection("Jwt:Secret").Get<string>();
        var jwtAudience = builder.Configuration.GetSection("Jwt:Audience").Get<string>();


        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
         .AddJwtBearer(options =>
         {
             options.TokenValidationParameters = new TokenValidationParameters
             {
                 ValidateIssuer = true,
                 ValidateAudience = true,
                 ValidateLifetime = true,
                 ValidateIssuerSigningKey = true,
                 ValidIssuer = jwtIssuer,
                 ValidAudience = jwtAudience,
                 IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
             };
         });

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigins",
                policy =>
                {
                    policy.WithOrigins("http://127.0.0.1:4200", "http://localhost:4200", "http://angular:4200", "https://angular:4200") // Allow Angular app origin
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials();
                });
        });



        builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        builder.Services.AddTransient<IAuthService, AuthService>();
        builder.Services.AddTransient<IContactService, ContactService>();
        builder.Services.AddTransient<IArticlesService, ArticlesService>();


        var app = builder.Build();

        app.UseCors("AllowSpecificOrigins");

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");


        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;

            var context = services.GetRequiredService<DatabaseContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }

        app.Run();

        Console.WriteLine("Nentindo has started :)");


    }
}
