using System;
using System.Configuration;
using System.Diagnostics;
using BookShop.WebTests.CodedUI.SearchMapClasses;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace BookShop.WebTests.CodedUI.Support
{
    public class CodedUIController
    {
        public static readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(10);

        public static CodedUIController Instance = new CodedUIController();

        public SearchMap Map { get; private set; }

        private static void Trace(string message)
        {
            Console.WriteLine("-> {0}", message);
        }

        public void Start()
        {
            if (Map != null) return;

            string appUrl = ConfigurationManager.AppSettings["AppUrl"];

            if(!Playback.IsInitialized)
                Playback.Initialize();
            Map = new SearchMap(appUrl);

            Trace("CodedUI initialized");
        }

        public void Stop()
        {
            if (Map == null) return;

            try
            {
                Playback.Cleanup();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex, "CodedUI stop error");
            }

            Map = null;
            Trace("CodedUI stopped");
        }
    }
}