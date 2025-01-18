using OpenQA.Selenium;

public class LoginPage
{
    private IWebDriver driver;

    public LoginPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    private IWebElement UsernameField => driver.FindElement(By.CssSelector("*[data-test=\"username\"]"));
    private IWebElement PasswordField => driver.FindElement(By.CssSelector("*[data-test=\"password\"]"));
    private IWebElement LoginButton => driver.FindElement(By.CssSelector("*[data-test=\"login-button\"]"));
    private IWebElement ErrorMessage => driver.FindElement(By.CssSelector("*[data-test=\"error\"]"));


    public void EnterUsername(string username)
    {
        UsernameField.SendKeys(username);
    }

    public void EnterPassword(string password)
    {
        PasswordField.SendKeys(password);
    }

    public void ClickLogin()
    {
        LoginButton.Click();
    }
    public void GoToPage()
    {
        driver.Navigate().GoToUrl("https://www.saucedemo.com/");
    }

    public void Login(string username, string password)
    {
        UsernameField.Click();
        UsernameField.SendKeys(username);
        PasswordField.Click();
        PasswordField.SendKeys(password);
        LoginButton.Click();
    }

    public string GetErrorMessage()
    {
        return ErrorMessage.Text;
    }
}
