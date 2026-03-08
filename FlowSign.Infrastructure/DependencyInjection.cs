namespace FlowSign.Infrastructure

public class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddScoped<ITemplateService, TemplateService>();
		services.AddScoped<IEmailService, EmailService>();
		return services;
    }

}
