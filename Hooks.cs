using OpenQA.Selenium;
using Reqnroll;
using Microsoft.Extensions.Configuration;
using LabCorpTests.Utils;
using AventStack.ExtentReports;

namespace LabCorpTests;

[Binding]
public class Hooks
{
    private readonly ScenarioContext scenarioContext;
    private IWebDriver driver;
    private IConfiguration configuration;
    public ExtentReports ExtentReports;
    public ExtentTest extentTest;

    public Hooks(ScenarioContext scenarioContext)
    {
        this.scenarioContext = scenarioContext;
        var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("Config.json", optional: false, reloadOnChange: true);

        configuration = builder.Build();
    }

    [BeforeScenario(Order = 0)]
    public void SetUp()
    {
        var browser = configuration["browser"];
        var url = configuration["baseURL"];
        bool headless = bool.TryParse(configuration["headless"], out bool parsedHeadless) && parsedHeadless;

        driver = DriverSetUp.BrowserSetUp(browser, headless);
        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl(url);
        scenarioContext.Set(driver, "browserDriver");
        ExtentReports = ExtentHelper.GetExtent();

    }
    
    [BeforeScenario(Order = 1)]
    public void BeforeScenario()
    {
        extentTest = ExtentReports.CreateTest(TestContext.CurrentContext.Test.Name);
        scenarioContext.Set(extentTest,"extentTest");
    }
    
    [AfterScenario(Order = 0)]
    public void AfterScenario()
    {
        if (scenarioContext.TestError != null)
        {
            string base64Screenshot = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
            extentTest.Fail("Test failed with error: " + scenarioContext.TestError.Message).AddScreenCaptureFromBase64String(base64Screenshot);
        }
        else
            extentTest.Pass("Test passed successfully.");

        ExtentReports.Flush();
    }
    
    [AfterScenario(Order =1)]
    public void TearDown()
    {
        var driver = scenarioContext.Get<IWebDriver>("browserDriver");
        driver.Quit();
    }
    
}
