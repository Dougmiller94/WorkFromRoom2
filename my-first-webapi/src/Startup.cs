using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using src.Controllers;
using src.Data;
using src.Dto;

using src.Persistance.Models;

namespace src
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Note, NoteBookWithoutNotesDto>();
                cfg.CreateMap<NoteBookWithoutNotesDto, Note>();



                cfg.CreateMap<Note, NoteTextDto>();
                cfg.CreateMap<NoteTextDto, Note>().ForMember(note => note.Id, opt => opt.Ignore());


                cfg.CreateMap<NoteTextDto, Note>();
                cfg.CreateMap<NoteWithoutNoteBookDto, Note>();
                cfg.CreateMap<Note, NoteWithoutNoteBookDto>();

                cfg.CreateMap<NoteBookWithoutNotesDto, NoteBook>();
                cfg.CreateMap<NoteBookTitleDto, NoteBook>();
                cfg.CreateMap<NoteBook, NoteBookWithoutNotesDto>();
                cfg.CreateMap<NoteBook, NoteBookTitleDto>();

            });

            configuration.AssertConfigurationIsValid();
            var mapper = configuration.CreateMapper();




            services.AddSingleton<IMapper>(sp => mapper);
            services.AddDbContext<MyContext>(options => options.UseMySql(Configuration.GetConnectionString("MySQL")));
            services.AddControllers();
            services.AddOpenApiDocument(); // add OpenAPI v3 document
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseOpenApi(); // serve OpenAPI/Swagger documents
                app.UseSwaggerUi3(); // serve Swagger UI
                app.UseReDoc(); // serve ReDoc UI
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
