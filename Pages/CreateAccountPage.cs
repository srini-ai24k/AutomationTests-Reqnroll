using OpenQA.Selenium;
using Reqnroll;

namespace LabCorpTests.Pages;

// This class represents the Candidate Application Page in the LabCorp application.
// It contains methods to interact with the application form, such as verifying its display and clicking the autofill button.
// The JobDetailsPage class inherits from RetryElements to utilize retry logic for element interactions.
public class CreateAccountPage(IWebDriver driver, ScenarioContext scenarioContext) : RetryElements
{
    private IWebDriver driver = driver;
    private ScenarioContext _scenarioContext = scenarioContext;
    private By backToJobPosting = By.XPath("//*[text()='Back to Job Posting']");
    private By createAccount = By.CssSelector("[data-automation-id='signInContent'] h2");

    public void VerifyIfCreateAccountPageIsDisplayed()
    {
        Assert.Multiple(() =>
        {
            Assert.That(VerifyDisplay(driver, backToJobPosting), Is.True, "Create Account page is not displayed.");
            Assert.That(VerifyDisplay(driver, createAccount), Is.True, "Create Account header is not displayed.");
        });
    }
    public void ClickBackToJobPosting()
    {
        RetryClick(driver, backToJobPosting);
    }
}
