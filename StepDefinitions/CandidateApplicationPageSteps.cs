using AventStack.ExtentReports;
using LabCorpTests.Pages;
using LabCorpTests.Utils;
using OpenQA.Selenium;
using Reqnroll;

namespace LabCorpTests.StepDefinitions;

[Binding]
public class CandidateApplicationPageSteps
{
    IWebDriver driver;
    private ScenarioContext _scenarioContext;
    public ExtentTest extentTest;
    CandidateApplicationPage candidateApplicationPage;
    public CandidateApplicationPageSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        driver = _scenarioContext.Get<IWebDriver>("browserDriver");
        extentTest = _scenarioContext.Get<ExtentTest>("extentTest");
        candidateApplicationPage = new CandidateApplicationPage(driver, scenarioContext);
    }

    [Then(@"I should see the start application form")]
    public void ThenIshouldseethestartapplicationform()
    {
        candidateApplicationPage.VerifyIfStartApplicationFormIsDisplayed();
        LogHelper.Log("Verified that the candidate's application form is displayed", extentTest);
    }
    
    [When(@"I click on autofill with resume")]
    public void WhenIclickonautofillwithresume()
    {
        candidateApplicationPage.ClickAutoFillWithResume();
        LogHelper.Log("Clicked on Autofill with Resume button.", extentTest);
    }


}
