using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using WorkflowCore.Interface;

namespace Apollo
{
    public static class ApolloDiExtensions
    {
        public static IServiceCollection AddApollo(this IServiceCollection services)
        {
            services.AddWorkflow();
            services.AddTransient<StartStep>();
            return services;
        }

        public static IServiceProvider ConfigureApollo(this IServiceProvider provider)
        {
            var workflowHost = provider.GetRequiredService<IWorkflowHost>();

            workflowHost.RegisterWorkflow<EmbeddedMessageWorkflow, EmbeddedMessageRequest>();
            workflowHost.Start();

            return provider;
        }
    }
}
