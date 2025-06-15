using OpenQA.Selenium;
using Reqnroll;

namespace LabCorpTests.Pages;

// This class represents the Candidate Application Page in the LabCorp application.
// It contains methods to interact with the application form, such as verifying its display and clicking the button.
// The JobDetailsPage class inherits from RetryElements to utilize retry logic for element interactions.
public class JobDetailsPage(IWebDriver driver, ScenarioContext scenarioContext) : RetryElements
{
    private IWebDriver driver = driver;
    private ScenarioContext _scenarioContext = scenarioContext;
    private By jobTitle = By.CssSelector("[data-automation-id='jobPostingHeader']");
    private By jobLocation = By.CssSelector("[data-automation-id='locations'] dd");
    private By jobId = By.CssSelector("[data-automation-id='requisitionId'] dd");
    // private By firstKeyResponsibility = By.XPath("//*[@data-automation-id='jobPostingDescription']/ul[1]/li[1]");
    // private By secondRequiredSkill = By.XPath("//*[@data-automation-id='jobPostingDescription']/ul[2]/li[2]");
    // private By firstSoftSkill = By.XPath("//*[@data-automation-id='jobPostingDescription']/ul[4]/li[1]");
    private By careersHome = By.CssSelector("[data-automation-id='navigationItem-Careers Home']");


    public void VerifyIfJobDetailsPageIsDisplayed()
    {
        Assert.Multiple(() =>
        {
            Assert.That(VerifyDisplay(driver, jobTitle), Is.True, "Job title is not displayed.");
            Assert.That(VerifyDisplay(driver, jobLocation), Is.True, "Job location is not displayed.");
            Assert.That(VerifyDisplay(driver, jobId), Is.True, "Job ID is not displayed.");
        });
    }

    //Validating the job details displayed on this page with the job details from the careers page
    public void ValidateJobDetails()
    {
        string jobTitleText = GetText(driver, jobTitle);
        string jobLocationText = GetText(driver, jobLocation).Split(' ')[0].Trim(); // Extracting location text before the parentheses
        string jobIdText = GetText(driver, jobId);
        // string firstKeyResponsibilityText = GetText(driver, firstKeyResponsibility);
        // string secondRequiredSkillText = GetText(driver, secondRequiredSkill);
        // string firstSoftSkillText = GetText(driver, firstSoftSkill);

        // Retreiving expected job details from the scenario context 
        if (_scenarioContext["JobDetails"] is not Dictionary<string, string> jobDetails)
        {
            throw new InvalidOperationException("Job details not found in scenario context.");
        }
        string expectedJobTitle = jobDetails["title"];
        string expectedJobLocation = jobDetails["location"];
        string expectedJobId = jobDetails["id"];
        // string expectedFirstKeyResponsibility = jobDetails["firstKeyResponsibility"];
        // string expectedSecondRequiredSkill = jobDetails["secondRequiredSkill"];
        // string expectedFirstSoftSkill = jobDetails["firstSoftSkill"];

        Assert.Multiple(() =>
        {
            Assert.That(jobTitleText, Is.EqualTo(expectedJobTitle), "Job title does not match.");
            Assert.That(expectedJobLocation, Does.Contain(jobLocationText), "Job location does not match.");
            Assert.That(expectedJobId, Does.Contain(jobIdText), "Job ID does not match.");
            // Assert.That(firstKeyResponsibilityText, Is.Not.Empty, "First key responsibility is empty.");
            // Assert.That(secondRequiredSkillText, Is.Not.Empty, "Second required skill is empty.");
            // Assert.That(firstSoftSkillText, Is.Not.Empty, "First soft skill is empty.");
        });
    }

    public void ClickCareersHome()
    {
        RetryClick(driver, careersHome);
        string title = driver.Title;
        Assert.That(title, Does.Contain("Careers"), "Failed to navigate to LabCorp careers page. Current title: " + title);
    }
}
