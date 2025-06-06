using OpenQA.Selenium;
using Reqnroll;

namespace LabCorpTests.Pages;

// This class represents the Candidate Application Page in the LabCorp application.
// It contains methods to interact with the application form, such as verifying its display and clicking the button.
public class CandidateApplicationPage(IWebDriver driver, ScenarioContext scenarioContext) : RetryElements
{
    private IWebDriver driver = driver;
    private ScenarioContext _scenarioContext = scenarioContext;
    private By startYourApplication = By.CssSelector("[data-automation-id='applyAdventurePage'] h2");
    private By autoFillWithResume = By.XPath("//*[text()='Autofill with Resume']");


    public void VerifyIfStartApplicationFormIsDisplayed()
    {
        Assert.Multiple(() =>
        {
            Assert.That(VerifyDisplay(driver, startYourApplication), Is.True, "Candidate's Job application page is not displayed.");
            Assert.That(VerifyDisplay(driver, autoFillWithResume), Is.True, "Candidate's Job application page is not displayed.");
        });

    }
    public void ClickAutoFillWithResume()
    {
        RetryClick(driver, autoFillWithResume);
    }

}
