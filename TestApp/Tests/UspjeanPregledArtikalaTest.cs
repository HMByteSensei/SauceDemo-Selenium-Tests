using NUnit.Framework;
using OpenQA.Selenium;

[TestFixture]
public class UspjeanPregledArtikalaTest
{
    private IWebDriver driver;
    private LoginPage loginPage;
    private ProductPage productPage;
    private CartPage cartPage;

    [SetUp]
    public void SetUp()
    {
        driver = DriverManager.GetDriver();
        loginPage = new LoginPage(driver);
        productPage = new ProductPage(driver);
        cartPage = new CartPage(driver);
    }

    [TearDown]
    protected void TearDown()
    {
        driver.Quit();
        driver.Dispose();
        DriverManager.QuitDriver();
    }

    [Test]
    public void TestPregledArtikalaUKorpi()
    {
        // Step 1: Otvoriti login stranicu
        loginPage.GoToPage();

        // Step 2: Logovati se s validnim kredencijalima
        loginPage.Login("standard_user", "secret_sauce");

        // Step 3: Dodati proizvod u korpu
        productPage.AddProductToCart();

        // Step 4: Otvoriti korpu
        productPage.OpenCart();

        // Step 5: Provjeriti da li korpa nije prazna
        Assert.That(cartPage.IsCartNotEmpty(), Is.True, "Korpa je prazna, iako je proizvod dodan.");
    }
}
