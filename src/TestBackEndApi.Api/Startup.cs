using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using TestBackEndApi.Domain.Commands.Alunos.Post;
using TestBackEndApi.Domain.Commands.Grades.Post;
using TestBackEndApi.Domain.Commands.Matriculas.Post;
using TestBackEndApi.Domain.Commands.Professores.Post;
using TestBackEndApi.Domain.Profiles;
using TestBackEndApi.Domain.Queries.Aluno.Get;
using TestBackEndApi.Domain.Queries.Grade.Get;
using TestBackEndApi.Domain.Queries.Professor.Get;
using TestBackEndApi.Infrastructure.Data.Interfaces;
using TestBackEndApi.Infrastructure.Data.Repositories;

namespace TestBackEndApi.Api
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
            services.AddControllers();
            services.AddCors();

            #region IoC
            services.AddScoped<IDbConnection>(db => new SqlConnection(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IProfessorRepository, ProfessorRepository>();
            services.AddScoped<IGradeRepository, GradeRepository>();
            services.AddScoped<IMatriculaRepository, MatriculaRepository>();

            services.Add(ServiceDescriptor.Transient(typeof(GetProfessorQueryValidator), typeof(GetProfessorQueryValidator)));
            services.Add(ServiceDescriptor.Transient(typeof(GetGradeQueryValidator), typeof(GetGradeQueryValidator)));

            services.AddMediatR(typeof(GetAlunoQueryHandler).Assembly);
            services.AddMediatR(typeof(GetGradeQueryHandler).Assembly);
            services.AddMediatR(typeof(AlunoCommandHandler).Assembly);
            services.AddMediatR(typeof(ProfessorCommandHandler).Assembly);
            services.AddMediatR(typeof(GradeCommandHandler).Assembly);
            services.AddMediatR(typeof(PostMatriculaCommandHandler).Assembly);
            services.AddMediatR(typeof(DeleteMatriculaCommandHandler).Assembly);

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new GetAlunoQueryResponseProfile());
                mc.AddProfile(new GetProfessorQueryResponseProfile());
                mc.AddProfile(new AlunoDtoProfile());
                mc.AddProfile(new ProfessorDtoProfile());
                mc.AddProfile(new AlunoCommandProfile());
                mc.AddProfile(new ProfessorCommandProfile());
                mc.AddProfile(new GradeCommandProfile());
                mc.AddProfile(new MatriculaCommandProfile());
                mc.AddProfile(new GetGradeAlunoQueryResponseProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            #endregion IoC

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Test Back-End API",
                    Version = "v1",
                    Description = "API desenvolvida para atender o projeto solicitado pela Anima Digital.",
                    TermsOfService = new Uri("http://tilosofia.com"),
                    Contact = new OpenApiContact
                    {
                        Name = "João Marcos Sakalauska",
                        Email = "jsakalauska@gmail.com",
                        Url = new Uri("http://tilosofia.com"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("http://tilosofia.com"),
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Test Back-End API");
                options.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
