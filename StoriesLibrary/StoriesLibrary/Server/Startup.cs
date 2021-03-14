using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Blazored.LocalStorage;
using StoriesLibrary.Data;
using StoriesLibrary.Config;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using StoriesLibrary.Areas.Identity;

namespace StoriesLibrary
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddRazorPages();
			services.AddServerSideBlazor();
			services.AddControllersWithViews();
			services.AddBlazoredLocalStorage();
			services.AddDbContextFactory<StoriesContext>(builder =>
			{
				builder.UseSqlServer(
					Configuration.GetConnectionString("DefaultConnection"))
				.EnableSensitiveDataLogging(true);
			});
			services.AddDbContext<StoriesContext>(builder =>
			{
				builder.UseSqlServer(
					Configuration.GetConnectionString("DefaultConnection"))
				.EnableSensitiveDataLogging(true);
			});

			services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
				.AddEntityFrameworkStores<StoriesContext>();
			services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
			services.AddDatabaseDeveloperPageExceptionFilter();

			services.AddSingleton(typeof(PaginationConfig), (ServiceProvider) =>
				{
					var paginationConfig = new PaginationConfig();
					this.Configuration.GetSection("Pagination").Bind(paginationConfig);
					return paginationConfig;
				});

			services.AddSingleton(typeof(StoriesStorageConfig), (ServiceProvider) =>
			{
				var storageConfig = new StoriesStorageConfig();
				this.Configuration.GetSection("StoriesStorage").Bind(storageConfig);
				return storageConfig;
			});
		}
		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseMigrationsEndPoint();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
				endpoints.MapBlazorHub();
				endpoints.MapFallbackToPage("/_Host");
			});
		}
	}
}
