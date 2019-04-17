using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using SimpleCMS.Configuration;

namespace SimpleCMS.Web.Host.Startup
{
    [DependsOn(
       typeof(SimpleCMSWebCoreModule))]
    public class SimpleCMSWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public SimpleCMSWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SimpleCMSWebHostModule).GetAssembly());
        }
    }
}
