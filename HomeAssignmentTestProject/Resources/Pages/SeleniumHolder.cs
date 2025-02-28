
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HomeAssignmentTestProject.Resources.Pages
{
    public class SeleniumHolder 
    {
        private IWebDriver? _driver;

        public static SeleniumHolder Instance { get; } = new();

        public IWebDriver? Driver
        {
            get
            {
                if (_driver is null) OpenBrowser();
                return _driver;
            }
        }

        public void OpenBrowser()
        {
            if (_driver is not null) return;
            var options = new ChromeOptions();
            options.AddArgument("--start-fullscreen");
            _driver = new ChromeDriver(options);
        }

        public void CloseBrowser()
        {
            if (_driver is null) return;
           _driver?.Quit();
            _driver = null;
        }
    }

}

