using System;
using System.Configuration;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

namespace CalculatorUnitTests.Driver
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class WinAppDriver : IDisposable
    {
        private WindowsDriver<WindowsElement> _driver;

        public WindowsDriver<WindowsElement> Current
        {
            get
            {
                if (_driver != null)
                {
                    return _driver;
                }

                var capabilities = new DesiredCapabilities();
                capabilities.SetCapability("app", "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");
                capabilities.SetCapability("deviceName", "WindowsPC");
                _driver = new WindowsDriver<WindowsElement>(new Uri(ConfigurationManager.AppSettings["winAppUri"]), capabilities);

                _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1.5));

                return _driver;
            }
        }

        public void Dispose()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver = null;
            }
        }
    }
}
