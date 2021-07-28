using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Todo.Web.Data;
using Todo.Web.GraphQL.Authors;
using Todo.Web.GraphQL.Books;
using Todo.Web.GraphQL.GraphQL.Extensions;
using Todo.Web.GraphQL.TodoItems;

namespace Todo.Web
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
            services.AddControllersWithViews();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration => configuration.RootPath = "ClientApp/build");

            services
                .AddGraphQLServer()
                .AddQueryType(d => d.Name("Query"))
                    .AddTypeExtension<TodoItemQueries>()
                    .AddTypeExtension<BookQueries>()
                    .AddTypeExtension<AuthorQueries>()
                .AddMutationType(d => d.Name("Mutation"))
                    .AddTypeExtension<TodoItemMutations>()
                    .AddTypeExtension<BookMutations>()
                    .AddTypeExtension<AuthorMutations>()
                .AddSubscriptionType(d => d.Name("Subscription"))
                    .AddTypeExtension<TodoItemSubscriptions>()
                .AddType<TodoItemType>()
                .AddType<BookType>()
                .AddType<AuthorType>()
                .EnableRelaySupport()
                .AddFiltering()
                .AddSorting()
                .AddProjections()
                .AddInMemorySubscriptions()
                .AddDataLoader<TodoItemByIdDataLoader>()
                .AddDataLoader<BookByIdDataLoader>()
                .AddDataLoader<AuthorByIdDataLoader>()
                .AddDiagnosticEventListener(sp => new ConsoleQueryLogger(sp.GetApplicationService<ILogger<ConsoleQueryLogger>>()))
                .AddDiagnosticEventListener(sp => new MiniProfilerQueryLogger());

            services
                .AddMiniProfiler(options => options.RouteBasePath = "/profiler")
                .AddEntityFramework();

            services.AddPooledDbContextFactory<ApplicationDbContext>(options => options.UseSqlite("Data Source=todo.db"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) { app.UseDeveloperExceptionPage(); }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
                app.UseHttpsRedirection();
            }

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();
            app.UseMiniProfiler();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
                endpoints.MapControllerRoute(name: "default", pattern: "{controller}/{action=Index}/{id?}");
            });

            if (env.IsDevelopment())
            {
                app.UseSpa(spa =>
                {
                    // https://github.com/dotnet/aspnetcore/blob/main/src/Middleware/Spa/SpaServices.Extensions/src/ReactDevelopmentServer/ReactDevelopmentServerMiddleware.cs
                    spa.Options.SourcePath = "ClientApp";
                    spa.Options.DevServerPort = 3000;
                    spa.Options.StartupTimeout = TimeSpan.FromSeconds(1);
                    spa.UseReactDevelopmentServer(npmScript: "dev:aspnet");
                });
            }
        }
    }
}
