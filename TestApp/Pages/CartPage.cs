using OpenQA.Selenium;
public class CartPage
{
    private IWebDriver driver;

    public CartPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    private IWebElement CartIcon => driver.FindElement(By.CssSelector(".shopping_cart_link"));
    private IWebElement CartItemList => driver.FindElement(By.CssSelector(".cart_list"));

    public void OpenCart()
    {
        CartIcon.Click();
    }

    public bool IsCartNotEmpty()
    {
        return CartItemList.FindElements(By.CssSelector(".cart_item")).Count > 0;
    }
    private IWebElement CheckoutButton => driver.FindElement(By.CssSelector("*[data-test=\"checkout\"]"));

    public void ProceedToCheckout()
    {
        CheckoutButton.Click();
    }
}
