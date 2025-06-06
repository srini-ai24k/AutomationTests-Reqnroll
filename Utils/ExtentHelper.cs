using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;

namespace LabCorpTests.Utils;

public class ExtentHelper
{
    public static ExtentReports ExtentReports;

    public static ExtentReports GetExtent()
    {
        if (ExtentReports == null)
        {
            ExtentReports = new ExtentReports();

            // Get the TestReport folder path dynamically
            string reportDirectory = Path.Combine(GetRootDirectory(), "TestReport");

            // Ensure the directory exists
            if (!Directory.Exists(reportDirectory))
            {
                Directory.CreateDirectory(reportDirectory);
            }

            // Keep only the last 5 reports (optional)
            var htmlFiles = Directory.GetFiles(reportDirectory, "*.html");
            if (htmlFiles.Length >= 5)
            {
                Array.Sort(htmlFiles); // Sort by name (date-based sorting)
                for (int i = 0; i < htmlFiles.Length - 5; i++)
                {
                    File.Delete(htmlFiles[i]); // Delete old reports
                }
            }

            // Generate new report file with timestamp
            string reportFilePath = Path.Combine(reportDirectory, "TestExecution" + DateTime.Now.ToString("_MMddyyyy_hhmmtt") + ".html");
            var reporter = new ExtentSparkReporter(reportFilePath);
            reporter.Config.DocumentTitle = "Test Execution Summary";
            reporter.Config.ReportName = "Test Automation Report";
            reporter.Config.Theme = Theme.Standard;

            ExtentReports.AttachReporter(reporter);
        }
        return ExtentReports;
    }
    /// Gets the root directory of the project by splitting the current directory at "bin".
    public static string GetRootDirectory()
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        return currentDirectory.Split("bin")[0];
    }
}
