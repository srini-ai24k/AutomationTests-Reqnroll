using OpenQA.Selenium;
using Reqnroll;

namespace LabCorpTests.Pages;

// This class represents the Candidate Application Page in the LabCorp application.
// It contains methods to interact with the application form, such as verifying its display and clicking button.
// The CareersPage class inherits from RetryElements to utilize retry logic for element interactions.
public class CareersPage(IWebDriver driver, ScenarioContext scenarioContext) : RetryElements
{
    private IWebDriver driver = driver;
    private ScenarioContext _scenarioContext = scenarioContext;
    private By jobSearchInput = By.XPath("//*[@placeholder='Search job title or location']");
    private By acceptAllCookies = By.Id("onetrust-accept-btn-handler");
    private By firstJobResult = By.CssSelector("ul[data-ph-at-id='jobs-list'] li:nth-child(1) a");
    private By jobTitle = By.XPath("//h1[@class='job-title']");
    private By jobLocation = By.ClassName("job-location");
    private By jobId = By.ClassName("jobId");
    private By firstKeyResponsibility = By.XPath("//*[@data-ph-at-id='jobdescription-text']/ul[1]/li[1]");
    private By secondRequiredSkill = By.XPath("//*[@data-ph-at-id='jobdescription-text']/ul[2]/li[2]");
    private By firstSoftSkill = By.XPath("//*[@data-ph-at-id='jobdescription-text']/ul[4]/li[1]");
    private By applyNow = By.XPath("//*[text()='Apply Now']");

    public void EnterJobSearch(string jobTitle)
    {
        var searchInputElement = driver.FindElement(jobSearchInput);
        searchInputElement.Clear();
        searchInputElement.SendKeys(jobTitle);
        searchInputElement.SendKeys(Keys.Enter);
    }

    public void ClickFirstJobResult()
    {
        RetryClick(driver, acceptAllCookies);
        RetryClick(driver, firstJobResult);
    }

    public void AssertJobDetails()
    {
        Assert.Multiple(() =>
        {
            Assert.That(VerifyDisplay(driver, this.jobTitle), Is.True, "Job title is not displayed.");
            Assert.That(VerifyDisplay(driver, this.jobLocation), Is.True, "Job location is not displayed.");
            Assert.That(VerifyDisplay(driver, this.jobId), Is.True, "Job ID is not displayed.");
            Assert.That(VerifyDisplay(driver, this.firstKeyResponsibility), Is.True, "First key responsibility is not displayed.");
            Assert.That(VerifyDisplay(driver, this.secondRequiredSkill), Is.True, "Second required skill is not displayed.");
            Assert.That(VerifyDisplay(driver, this.firstSoftSkill), Is.True, "First soft skill is not displayed.");
        });

        var jobTitle = GetText(driver, this.jobTitle);
        var jobLocation = GetText(driver, this.jobLocation);
        var jobId = GetText(driver, this.jobId);
        var firstKeyResponsibility = GetText(driver, this.firstKeyResponsibility);
        var secondRequiredSkill = GetText(driver, this.secondRequiredSkill);
        var firstSoftSkill = GetText(driver, this.firstSoftSkill);

        Dictionary<string, string> jobDetails = new()
        {
            { "title", jobTitle },
            { "location", jobLocation },
            { "id", jobId },
            { "firstKeyResponsibility", firstKeyResponsibility },
            { "secondRequiredSkill", secondRequiredSkill },
            { "firstSoftSkill", firstSoftSkill }
        };
        _scenarioContext["JobDetails"] = jobDetails;
    }
    public void ClickApplyNow()
    {
        var currentWindow = driver.CurrentWindowHandle;
        RetryClick(driver, applyNow);
        IList<string> windows = driver.WindowHandles;
        foreach (string window in windows)
        {
            if (window != currentWindow)
            {
                driver.SwitchTo().Window(window);
            }
        }
        _scenarioContext["currentWindow"] = currentWindow;
    }

}
