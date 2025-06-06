using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace LabCorpTests.Utils;

public class DriverSetUp
{
    public static IWebDriver BrowserSetUp(string browser, bool headless = false)
    {
        switch(browser.ToLower())
        {
            case "chrome":
                var chromeOptions = new ChromeOptions();
                chromeOptions.AddArgument("--incognito");
               
                if (headless)
                {
                    chromeOptions.AddArgument("--headless");
                    chromeOptions.AddArgument("--disable-gpu");
                    chromeOptions.AddArgument("--window-size=1920,1080");
                }
                return new ChromeDriver(chromeOptions);

            case "firefox":
                var firefoxOptions = new FirefoxOptions();
                firefoxOptions.AddArgument("--private");
                if (headless)
                {
                    firefoxOptions.AddArgument("--headless");
                    firefoxOptions.AddArgument("--disable-gpu");
                    firefoxOptions.AddArgument("--window-size=1920,1080");
                }
                return new FirefoxDriver(firefoxOptions);

            case "edge":
                 var edgeOptions = new EdgeOptions();
                if (headless)
                {
                    edgeOptions.AddArgument("--headless");
                    edgeOptions.AddArgument("--disable-gpu");
                    edgeOptions.AddArgument("--window-size=700,1000");
                }
                return new EdgeDriver(edgeOptions);
            
            default:
                return new ChromeDriver();
        }
    }

}
