using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace HigherKnowledge.ReferenceService
{
    using Common.Applications;

    public class Startup : DefaultStartup
    {
        public Startup(IHostingEnvironment env) : base(env) { }

        public override void ConfigureServices(IServiceCollection services) {
            services.AddDefaults(Configuration);
            
        }

        public static void Main(string[] args) => Run<Startup>(args);
    }
}
