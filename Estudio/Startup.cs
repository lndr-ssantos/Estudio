using System;
using Estudio.Data;
using Estudio.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Estudio {
	public class Startup {
		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services) {
			services.Configure<CookiePolicyOptions>(options => {
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});
			
			//Configuração session
			services.AddDistributedMemoryCache();
			services.AddSession(options =>
			{
				// Set a short timeout for easy testing.
				//options.IdleTimeout = TimeSpan.FromSeconds(10);
				options.Cookie.HttpOnly = true;
				// Make the session cookie essential
				options.Cookie.IsEssential = true;
			});

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
			
			services.AddEntityFrameworkNpgsql().AddDbContext<EstudioContext>(options => options.UseNpgsql(Configuration.GetConnectionString("EstudioBD")));
			services.AddScoped(typeof (IConsumiveisServices), typeof (ConsumiveisServices));
			services.AddHttpContextAccessor();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
			if (env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
			} else {
				app.UseExceptionHandler("/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseSession();
			app.UseCookiePolicy();

			app.UseMvc();
		}
	}
}
