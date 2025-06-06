using OpenQA.Selenium;

namespace LabCorpTests.Pages;

// <summary>
// RetryElements class provides methods to handle common web element interactions with retry logic.
// It includes methods to get web elements, click on them, verify their display status, and retrieve their text.
public class RetryElements
{
    IWebElement? element = null;
    // Gets a web element by its locator with retry logic to handle stale elements.
    public IWebElement GetWebElement(IWebDriver driver, By elementBy, int timeout = 3000, int retryCount = 3)
    {
        int attempt = 0;
        do
        {
            try
            {
                element = driver.FindElement(elementBy);
                break;
            }
            catch (StaleElementReferenceException)
            {
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                Thread.Sleep(timeout);
                attempt++;
                if (attempt == retryCount)
                    throw new WebDriverException(ex.Message + ":" + elementBy.ToString());
            }
        } while (attempt < retryCount);
        return element;
    }
    // Clicks on a web element with retry logic to handle stale elements.
    public void RetryClick(IWebDriver driver, By elementBy, int timeout = 3000, int retryCount = 3)
    {
        int attempt = 0;
        do
        {
            try
            {
                element = driver.FindElement(elementBy);
                element.Click();
                break;
            }
            catch (StaleElementReferenceException)
            {
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                Thread.Sleep(timeout);
                attempt++;
                if (attempt == retryCount)
                    throw new WebDriverException(ex.Message + ":" + elementBy.ToString());
            }
        } while (attempt < retryCount);
    }

    // Verifies if a web element is displayed with retry logic to handle stale elements.
    public bool VerifyDisplay(IWebDriver driver, By elementBy)
    {
        bool display = false;
        try
        {
            IWebElement element = GetWebElement(driver, elementBy);
            if (element.Displayed)
                display = true;
        }
        catch (StaleElementReferenceException)
        {
            Thread.Sleep(2000);
            return VerifyDisplay(driver, elementBy);
        }
        catch (NoSuchElementException)
        {
            return display;
        }
        return display;
    }
    // Retrieves the text of a web element with retry logic to handle stale elements.
    public string GetText(IWebDriver driver, By elementBy)
    {
        IWebElement element = GetWebElement(driver, elementBy);
        return element.Text;
    }

}
