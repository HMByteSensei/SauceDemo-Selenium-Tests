using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

[TestFixture]
public class UspjesnaFinalizacijaKupovineTest
{
    private IWebDriver driver;
    private LoginPage loginPage;
    private CartPage cartPage;
    private CheckoutPage checkoutPage;

    [SetUp]
    public void SetUp()
    {
        driver = DriverManager.GetDriver();
        loginPage = new LoginPage(driver);
        cartPage = new CartPage(driver);
        checkoutPage = new CheckoutPage(driver);
    }

    [TearDown]
    protected void TearDown()
    {
        driver.Quit();
        driver.Dispose();
        DriverManager.QuitDriver();
    }

    [Test]
    public void TestFinalizacijaKupovine()
    {
        // Step 1: Login
        loginPage.GoToPage();

        // Perform login
        loginPage.Login("standard_user", "secret_sauce");

        // Step 2: Open cart and proceed to checkout
        cartPage.OpenCart();
        cartPage.ProceedToCheckout();

        // Step 3: Enter checkout information
        checkoutPage.EnterCheckoutInformation("Neko", "Nekic", "12345");

        // Step 4: Complete purchase
        checkoutPage.CompletePurchase();

        // Step 5: Validate confirmation message
        string confirmationMessage = checkoutPage.GetConfirmationMessage();
        Assert.That(confirmationMessage, Is.EqualTo("Thank you for your order!"), "The confirmation message is not as expected.");
    }
}
