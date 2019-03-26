using Models;
using System.Configuration;
using Topshelf;

namespace BaseService
{
    class Program
    {
        private static ApplicationSettingsConfiguration settings = new ApplicationSettingsConfiguration();
        static void Main(string[] args)
        {
            HostFactory.Run(host =>
            {
                host.SetServiceName(settings.GetApplicationSetting("ServiceName").Value);
                host.SetDisplayName(settings.GetApplicationSetting("ServiceName").Value);
                host.SetDescription($"Open Industry Windows Service {settings.GetApplicationSetting("ServiceName").Value}");
                host.StartAutomatically();
                host.RunAsLocalService();
                host.EnableServiceRecovery(src =>
                {
                    src.OnCrashOnly();
                    src.RestartService(delayInMinutes: 0);
                    src.RestartService(delayInMinutes: 1);
                    // Corresponds to ‘Subsequent failures: Restart the Service’
                    src.RestartService(delayInMinutes: 5);

                    src.SetResetPeriod(days: 1);
                });

                host.Service<ServiceController>();
            });
        }
    }
}
