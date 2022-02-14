using Autofac;
using Bet.Domain.Service;
using Bet.Infrastructure.Context;
using Bet.Infrastructure.Models;
using Bet.Infrastructure.Repository;
using Bet.API.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using Bet.API.Validators;

namespace Bet.API
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
            services.AddDbContext<BettingContext>(options => options.
               UseInMemoryDatabase(databaseName: "GamblingDB"));

            //services.AddDbContext<BettingContext>(options =>
            //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<BettingContext>()
            .AddDefaultTokenProviders();
           
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                   
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Auth:JwtBearer:SecurityKey"])),

                
                    ValidateIssuer = true,
                    ValidIssuer = Configuration["Auth:JwtBearer:Issuer"],

                   
                    ValidateAudience = true,
                    ValidAudience = Configuration["Auth:JwtBearer:Audience"],
                };
            });

            services.AddControllers()
                 .AddJsonOptions(
                     options =>
                     {
                         options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                         options.JsonSerializerOptions.IgnoreNullValues = true;
                     })
                 .AddFluentValidation(
                     fv =>
                     {
                         fv.RegisterValidatorsFromAssemblyContaining<CreateBetCommandValidator>();
                         fv.RegisterValidatorsFromAssemblyContaining<CreateUserCommandValidator>();
                         fv.RegisterValidatorsFromAssemblyContaining<LoginModelValidator>();
                         fv.ImplicitlyValidateChildProperties = true;
                     });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Betting.API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            services.AddScoped<IBettingContext, BettingContext>();
            services.AddScoped<IBettingRepository, BettingRepository>();
            services.AddScoped<IBettingService, BettingService>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
        }
        public virtual void ConfigureContainer(ContainerBuilder builder)
        {
             // register all the command handlers.
            builder.RegisterAssemblyTypes(typeof(CreateUserCommand).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            // mediatR
            builder.RegisterAssemblyTypes(typeof(IMediator).Assembly).AsImplementedInterfaces();
            builder.Register<ServiceFactory>(context =>
            {
                var componentContext = context.Resolve<IComponentContext>();
                return t =>
                {
                    object o;
                    return componentContext.TryResolve(t, out o!) ? o : default!;
                };
            });
        }

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Betting.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
