using System;
using OpenQA.Selenium;
using Reqnroll;

namespace LabCorpTests.Pages;

// This file contains the HomePage class which represents the home page of the LabCorp application.
// It includes methods to validate the application launch and to navigate to the careers page.
// The HomePage class inherits from RetryElements to utilize retry logic for element interactions.
public class HomePage(IWebDriver driver, ScenarioContext scenarioContext) : RetryElements
{
    private IWebDriver driver = driver;
    private ScenarioContext _scenarioContext = scenarioContext;
    private By careersLink = By.CssSelector("a[href*='careers'][target='_self']");

    public void ValidateApplicationLaunch()
    {
        string title = driver.Title;
        Assert.That(title, Does.Contain("Lab Diagnostics & Drug Development"), "Application did not launch successfully. Current title: " + title);
    }
    public void ClickCareersLink()
    {
        RetryClick(driver, careersLink);
        string title = driver.Title;
        Assert.That(title, Does.Contain("Careers"), "Failed to navigate to LabCorp careers page. Current title: " + title);
    }
}
