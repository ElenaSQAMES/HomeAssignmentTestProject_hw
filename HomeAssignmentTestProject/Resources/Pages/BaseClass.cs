using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;

namespace HomeAssignmentTestProject.Resources.Pages;

public class BaseClass
{
    private IWebDriver _driver;

    public BaseClass(IWebDriver driver)
    {
        _driver = driver;
    }

    protected BaseClass()
    {
        throw new NotImplementedException();
    }

    [SetUp]
    public void SetUp()
    {
        BrowserType browserType = BrowserType.Chrome; // Change this to select a different browser

        _driver = WebDriverFactory.CreateDriver(browserType);
        SeleniumHolder.Instance.OpenBrowser();
    }

    [TearDown]
    public void TearDown()
    {
        SeleniumHolder.Instance.CloseBrowser();
    }

    public enum BrowserType
    {
        Chrome,
        Firefox,
        Edge,
        Safari
    }

    public static class WebDriverFactory
    {
        public static IWebDriver CreateDriver(BrowserType browserType)
        {
            return browserType switch
            {
                BrowserType.Chrome => new ChromeDriver(),
                BrowserType.Firefox => new FirefoxDriver(),
                BrowserType.Edge => new EdgeDriver(),
                BrowserType.Safari => new SafariDriver(),
                _ => throw new ArgumentException($"Unsupported browser type: {browserType}"),
            };
        }
    }
}
