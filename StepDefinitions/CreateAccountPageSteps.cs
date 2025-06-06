using AventStack.ExtentReports;
using LabCorpTests.Pages;
using LabCorpTests.Utils;
using OpenQA.Selenium;
using Reqnroll;

namespace LabCorpTests.StepDefinitions;

[Binding]
public class CreateAccountPageSteps
{
    IWebDriver driver;
    private ScenarioContext _scenarioContext;
    public ExtentTest extentTest;
    CreateAccountPage createAccountPage;
    public CreateAccountPageSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        driver = _scenarioContext.Get<IWebDriver>("browserDriver");
        extentTest = _scenarioContext.Get<ExtentTest>("extentTest");
        createAccountPage = new CreateAccountPage(driver, scenarioContext);
    }


    [When(@"I should see create account form")]
    public void WhenIshouldseecreateaccountform()
    {
        createAccountPage.VerifyIfCreateAccountPageIsDisplayed();
        LogHelper.Log("Verified that the create account form is displayed.", extentTest);
    }

    [When(@"I click on back to job posting")]
    public void WhenIclickonbacktojobposting()
    {
        createAccountPage.ClickBackToJobPosting();
        LogHelper.Log("Clicked on Back to Job Posting button.", extentTest);
    }


}
