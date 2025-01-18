using OpenQA.Selenium;

public class MainPage
{
    private IWebDriver driver;

    public MainPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    private IWebElement AddToCartButton => driver.FindElement(By.CssSelector("*[data-test=\"add-to-cart-sauce-labs-backpack\"]"));
    private IWebElement RemoveFromCartButton => driver.FindElement(By.CssSelector("*[data-test=\"remove-sauce-labs-backpack\"]"));

    public void ClickAddToCart()
    {
        AddToCartButton.Click();
    }

    public void ClickRemoveFromCart()
    {
        RemoveFromCartButton.Click();
    }

    public void DoubleClickRemoveFromCart()
    {
        var actions = new OpenQA.Selenium.Interactions.Actions(driver);
        actions.DoubleClick(RemoveFromCartButton).Perform();
    }
}
