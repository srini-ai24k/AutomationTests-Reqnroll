using AventStack.ExtentReports;

namespace LabCorpTests.Utils;

public static class LogHelper
{
    public static void Log(string message,ExtentTest extentTest)
    {
        extentTest.Log(Status.Info,message);
    }
}
