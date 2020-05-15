using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using QueHice.Configuration;

namespace QueHice.Web.Host.Startup
{
    [DependsOn(
       typeof(QueHiceWebCoreModule))]
    public class QueHiceWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public QueHiceWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(QueHiceWebHostModule).GetAssembly());
        }
    }
}
