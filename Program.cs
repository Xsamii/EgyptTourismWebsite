using EgyptTouristWebSite.Context;
using EgyptTouristWebSite.Models;
using EgyptTouristWebSite.Repository;
using EgyptTouristWebSite.Repository.Interfaces;
using EgyptTouristWebSite.Services;
using EgyptTouristWebSite.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EgyptTouristWebSite
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();
			builder.Services.AddDbContext<DataBaseContext>(
				options=>  
					options.UseNpgsql(builder.Configuration.GetConnectionString("ASconnectionString"))
				);
        
            //builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<DataBaseContext>();
            //adding identity service
            builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
			{
				options.Password.RequireLowercase = true;
				options.Password.RequireUppercase = false;
				options.Password.RequireNonAlphanumeric = false;

			}).AddEntityFrameworkStores<DataBaseContext>();
			//External Login by Google
			builder.Services.AddAuthentication().AddGoogle(options =>
			{
				var cred = builder.Configuration.GetSection("Authentication");
				options.ClientId = cred["clientId"];
				options.ClientSecret = cred["clientSecret"];
			});

			#region injection
			builder.Services.AddScoped<IprofileService,ProfileService>();
			builder.Services.AddScoped<IHomeService, HomeService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IServicesService, ServicesService>();
			builder.Services.AddScoped<IInterPlaceService, InterPlaceService>();
			builder.Services.AddScoped<IAccommodationService, AccommodationService>();
			builder.Services.AddScoped<IAccommodationRepo, AccommodationRepository>();
			builder.Services.AddScoped<IPlaceRepo, InterestingPlaceRepo>();
			builder.Services.AddScoped<ITourGuidRepo, TourGuideRepositry>();
            builder.Services.AddScoped<IServiceRepo, ServiceRepo>();
            builder.Services.AddScoped<ITravelAgencyRepo, TravelAgencyRepo>();
            #endregion
            var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
			}
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}