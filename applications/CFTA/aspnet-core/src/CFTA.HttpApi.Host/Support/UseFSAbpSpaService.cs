using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace Microsoft.AspNetCore.Builder
{
    public static class AbpSpaServiceExtensions
    {

        public static IApplicationBuilder UseFSAbpSpaService(this IApplicationBuilder app)
        {
            app.UseSpaStaticFiles();
            app.Map("/cfta-admin", application =>
            {
                application.UseSpa(spa =>
                {
                    spa.Options.SourcePath = string.Format("wwwroot/{0}", "cfta-admin");
                    spa.Options.DefaultPageStaticFileOptions = new StaticFileOptions
                    {
                        FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "cfta-admin"))
                    };
                });
            });
            app.Map("/admin", application =>
            {
                application.UseSpa(spa =>
                {
                    spa.Options.SourcePath = string.Format("wwwroot/{0}", "cfta-admin");
                    spa.Options.DefaultPageStaticFileOptions = new StaticFileOptions
                    {
                        FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "cfta-admin"))
                    };
                });
            });
            return app;
        }
    }
}