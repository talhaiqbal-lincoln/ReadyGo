using Microsoft.AspNetCore.Builder;

namespace ReadyGo.Infrastructure.Extension
{
    public static class ConfigureContainer
    {
        public static void ConfigureSwagger(this IApplicationBuilder app)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.) specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(setupAction =>
            {
                // Disable swagger schemas at bottom
                setupAction.DefaultModelsExpandDepth(-1);

                setupAction.SwaggerEndpoint("/swagger/mobile/swagger.json", "LightHouse Mobile API");
                setupAction.SwaggerEndpoint("/swagger/client/swagger.json", "LightHouse Client API");
            });
        }
    }
}
