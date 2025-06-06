using AventStack.ExtentReports;
using LabCorpTests.Pages;
using LabCorpTests.Utils;
using OpenQA.Selenium;
using Reqnroll;

namespace LabCorpTests.StepDefinitions;

[Binding]
public class CareersPageSteps
{
    IWebDriver driver;
    private ScenarioContext _scenarioContext;
    public ExtentTest extentTest;
    CareersPage careersPage;
    public CareersPageSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        extentTest = _scenarioContext.Get<ExtentTest>("extentTest");
        driver = _scenarioContext.Get<IWebDriver>("browserDriver");
        careersPage = new CareersPage(driver, scenarioContext);
    }

    [Given(@"I search for ""(.*)""")]
    public void GivenIsearchfor(string searchTerm)
    {
        if (string.IsNullOrEmpty(searchTerm))
            throw new ArgumentException("Search term cannot be null or empty.", nameof(searchTerm));

        careersPage.EnterJobSearch(searchTerm);
        LogHelper.Log($"Searched for job title or location: {searchTerm}", extentTest);
    }

    [When(@"I select the first job listing")]
    public void WhenIselectthefirstjoblisting()
    {
        careersPage.ClickFirstJobResult();
        LogHelper.Log("Selected the first job listing from the search results.", extentTest);
    }
    
    [Then(@"I should see the job details")]
    public void ThenIshouldseethejobdetails()
    {
        careersPage.AssertJobDetails();
        LogHelper.Log("Verified that the job details are displayed correctly.", extentTest);
    }

    [Then(@"I click on Apply Now")]
    public void ThenIclickonApplyNow()
    {
        careersPage.ClickApplyNow();
        LogHelper.Log("Clicked on Apply Now button for the job listing.", extentTest);
    }



}
