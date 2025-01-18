using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class ProductPage
{
    private IWebDriver driver;

    public ProductPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    private IWebElement AddToCartButton => driver.FindElement(By.CssSelector("*[data-test=\"add-to-cart-sauce-labs-bike-light\"]"));
    private IWebElement CartIcon => driver.FindElement(By.CssSelector("*[data-test=\"shopping-cart-link\"]"));

    public void AddProductToCart()
    {
        AddToCartButton.Click();
    }

    public void OpenCart()
    {
        CartIcon.Click();
    }
    private IWebElement SortDropdown => driver.FindElement(By.CssSelector("*[data-test=\"product-sort-container\"]"));
    private IList<IWebElement> ProductNames => driver.FindElements(By.ClassName("inventory_item_name"));

    public void SelectFilter(string filterOption)
    {
        var selectElement = new SelectElement(SortDropdown);
        selectElement.SelectByText(filterOption);
    }

    public List<string> GetProductNames()
    {
        return ProductNames.Select(product => product.Text).ToList();
    }
}
