using OpenQA.Selenium;
public class CheckoutPage
{
    private IWebDriver driver;

    public CheckoutPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    private IWebElement FirstNameField => driver.FindElement(By.CssSelector("*[data-test=\"firstName\"]"));
    private IWebElement LastNameField => driver.FindElement(By.CssSelector("*[data-test=\"lastName\"]"));
    private IWebElement PostalCodeField => driver.FindElement(By.CssSelector("*[data-test=\"postalCode\"]"));
    private IWebElement ContinueButton => driver.FindElement(By.CssSelector("*[data-test=\"continue\"]"));
    private IWebElement FinishButton => driver.FindElement(By.CssSelector("*[data-test=\"finish\"]"));
    private IWebElement ConfirmationMessage => driver.FindElement(By.CssSelector(".complete-header"));

    public void EnterCheckoutInformation(string firstName, string lastName, string postalCode)
    {
        FirstNameField.SendKeys(firstName);
        LastNameField.SendKeys(lastName);
        PostalCodeField.SendKeys(postalCode);
        ContinueButton.Click();
    }

    public void CompletePurchase()
    {
        FinishButton.Click();
    }

    public string GetConfirmationMessage()
    {
        return ConfirmationMessage.Text;
    }
}
