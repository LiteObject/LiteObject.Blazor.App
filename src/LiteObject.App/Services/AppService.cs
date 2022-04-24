using System.Reflection;

namespace LiteObject.App.Services
{
    public class AppService : IAppService
    {
        public string Version =>
            Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion ?? "0.0.0";
    }
}
