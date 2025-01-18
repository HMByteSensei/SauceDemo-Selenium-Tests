using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;

[TestFixture]
public class BugFiltriranjeArtikalaTest
{
    private IWebDriver driver;
    private LoginPage loginPage;

    [SetUp]
    public void SetUp()
    {
        driver = DriverManager.GetDriver();
        loginPage = new LoginPage(driver);
        driver.Navigate().GoToUrl("https://www.saucedemo.com/");
    }

    [TearDown]
    public void TearDown()
    {
        driver.Dispose();
        DriverManager.QuitDriver();
    }

    [Test]
    public void TestFiltriranjeArtikala()
    {
        loginPage.EnterUsername("problem_user");
        loginPage.EnterPassword("secret_sauce");
        loginPage.ClickLogin();

        var dropdown = driver.FindElement(By.CssSelector("*[data-test=\"product-sort-container\"]"));
        dropdown.Click();
        dropdown.FindElement(By.XPath("//option[. = 'Name (A to Z)']")).Click();

        StringAssert.Contains("Sauce Labs Backpack", driver.PageSource);
        //Assert.IsTrue(driver.PageSource.Contains("Sauce Labs Backpack")); // Primer provjere
    }
}
