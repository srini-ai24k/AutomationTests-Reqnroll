using System;
using AventStack.ExtentReports;
using LabCorpTests.Pages;
using LabCorpTests.Utils;
using OpenQA.Selenium;
using Reqnroll;

namespace LabCorpTests.StepDefinitions;

[Binding]
public class HomePageSteps
{
    IWebDriver driver;
    private ScenarioContext _scenarioContext;
    public ExtentTest extentTest;
    HomePage homePage;
    public HomePageSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        driver = _scenarioContext.Get<IWebDriver>("browserDriver");
        extentTest = _scenarioContext.Get<ExtentTest>("extentTest");
        homePage = new HomePage(driver, scenarioContext);
    }


    [Given(@"I launch the LabCorp application")]
    public void GivenIlaunchtheLabCorpapplication()
    {
        homePage.ValidateApplicationLaunch();
        LogHelper.Log("Application launched successfully.", extentTest);
    }

    [Given(@"I navigate to LabCorp careers page")]
    public void GivenInavigatetoLabCorpcareerspage()
    {
        homePage.ClickCareersLink();
        LogHelper.Log("Navigated to LabCorp careers page.", extentTest);
    }


}
