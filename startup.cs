using EducWebApi.Models;
using FluentAssertions.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducWebApi.Controllers
{
    public class Startup
    { public Startup(IConfiguration configuration) { Configuration = configuration; }
        public IConfiguration Configuration { get; }
        //This method gets called by the runtime. Use this method to add services
        public void ConfiugureServices(IServiceCollection services) {
           Services.AddController();
        Services.AddDbContext<AppDbContext>(x => { x.UseSqlServer(COnfiguration.GetConnectionString
             ("EducDbContext") });
                services.AddCors();
            }
        public void Configure(ApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) { app.UseDeveloperExceptionPage(); }
        }
        //T
