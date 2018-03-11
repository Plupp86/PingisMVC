using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PingisMVC.Models;
using PingisMVC.Models.Entities;

namespace PingisMVC
{
	public class Startup
	{
		IConfiguration conf;
		public Startup(IConfiguration conf)
		{
			this.conf = conf;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			var connString = conf.GetConnectionString("LocalConnection");
			

			services.AddDbContext<PingisContext>(o => o.UseSqlServer(connString));  //Måste ligga före identityContexten
			services.AddTransient<Repository>();
			//services.AddAuthentication(CookieAuthentication)
			services.AddMvc();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			//if (env.IsDevelopment())
			//{
				app.UseDeveloperExceptionPage();
			//}
			//else
			//{
			//	app.UseExceptionHandler("/Error/ServerError");
			//	app.UseStatusCodePagesWithRedirects("/Error/HttpError/{0}");
			//}

			app.UseMvcWithDefaultRoute();
			app.UseStaticFiles();
			//app.UseAuthentication();
		}
	}
}
