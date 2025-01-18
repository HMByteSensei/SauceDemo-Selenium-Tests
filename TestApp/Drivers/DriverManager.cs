using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class DriverManager
{
    private static IWebDriver _driver;

    private DriverManager() { }

    public static IWebDriver GetDriver()
    {
        if (_driver == null)
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }
        return _driver;
    }

    public static void QuitDriver()
    {
        if (_driver != null)
        {
            _driver.Quit();
            _driver = null;
        }
    }
}
