using Models;
using OpenIndustryFrameworkClient;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using Topshelf;
using Timer = System.Timers.Timer;

namespace BaseService
{
    class ServiceController : ServiceControl
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static ApplicationSettingsConfiguration Settings = new ApplicationSettingsConfiguration();
        private static ClientsConfiguration ClientsConfiguration = new ClientsConfiguration();
        private static List<Client> Clients;
        private Timer _syncTimer;
        private static object s_lock = new object();

        private ClientController clientController;
        
        /// <summary>
        /// Starts the windows service
        /// </summary>
        /// <param name="hostControl"></param>
        /// <returns></returns>
        public bool Start(HostControl hostControl)
        {
            int pollTimeSeconds = Int16.Parse(Settings.GetApplicationSetting("PollTimeSeconds").Value) * 1000;

            Clients = ClientsConfiguration.ClientElementsAsList;

            try
            {
                clientController = new ClientController( );
            }
            catch (Exception ex)
            {
                log.Error("Service Start", ex);
                return false;
            }

            _syncTimer = new Timer();

            if (pollTimeSeconds > -1)
            {
                _syncTimer.Interval = pollTimeSeconds;
                _syncTimer.Enabled = true;
                _syncTimer.Elapsed += RunJob;
            }
            else
            {
                RunJob(null, null);
            }

            log.Info("Service Start");

            return true;
        }

        /// <summary>
        /// Stops the windows service
        /// </summary>
        /// <param name="hostControl"></param>
        /// <returns></returns>
        public bool Stop(HostControl hostControl)
        {
            _syncTimer.Enabled = false;

            log.Info("Service Stop");

            return true;
        }

        /// <summary>
        /// Job runner event, with lock if the job still running
        /// </summary>
        /// <param name="state"></param>
        /// <param name="elapsedEventArgs"></param>
        private void RunJob(object state, ElapsedEventArgs elapsedEventArgs)
        {
            //Prevents the job firing until it finishes its job
            if (Monitor.TryEnter(s_lock))
            {
                try
                {
                    Clients.ForEach ( client => clientController.Execute(client) );
                }
                catch (Exception ex)
                {
                    log.Error("RunJob ", ex);
                }
                finally
                {
                    //unlock the job
                    Monitor.Exit(s_lock);
                }
            }
        }
    }
}

