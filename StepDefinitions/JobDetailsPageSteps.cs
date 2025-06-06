using AventStack.ExtentReports;
using LabCorpTests.Pages;
using LabCorpTests.Utils;
using OpenQA.Selenium;
using Reqnroll;

namespace LabCorpTests.StepDefinitions;

[Binding]
public class JobDetailsPageSteps
{
    IWebDriver driver;
    private ScenarioContext _scenarioContext;
    public ExtentTest extentTest;
    JobDetailsPage jobDetailsPage;
    public JobDetailsPageSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        driver = _scenarioContext.Get<IWebDriver>("browserDriver");
        extentTest = _scenarioContext.Get<ExtentTest>("extentTest");
        jobDetailsPage = new JobDetailsPage(driver, scenarioContext);
    }

    [Then(@"I should see the job details again")]
    public void ThenIshouldseethejobdetailsagain()
    {
        jobDetailsPage.VerifyIfJobDetailsPageIsDisplayed();
        LogHelper.Log("Verified that the job details page is displayed.", extentTest);
    }

    [Then(@"I Validate the job details")]
    public void ThenIValidatethejobdetails()
    {
        jobDetailsPage.ValidateJobDetails();
        LogHelper.Log("Validated the job details displayed on the job details page.", extentTest);
    }

    [Then(@"I return to job search")]
    public void ThenIreturntojobsearch()
    {
        jobDetailsPage.ClickCareersHome();
        LogHelper.Log("Clicked on Careers Home to return to job search.", extentTest);
    }

}
