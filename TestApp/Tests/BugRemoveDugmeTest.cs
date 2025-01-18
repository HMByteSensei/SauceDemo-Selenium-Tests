using NUnit.Framework;
using OpenQA.Selenium;

[TestFixture]
public class BugRemoveDugmeTest
{
    private IWebDriver driver;
    private LoginPage loginPage;
    private MainPage mainPage;

    [SetUp]
    public void SetUp()
    {
        driver = DriverManager.GetDriver();
        loginPage = new LoginPage(driver);
        mainPage = new MainPage(driver);
        driver.Navigate().GoToUrl("https://www.saucedemo.com/");
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
        DriverManager.QuitDriver();
    }

    [Test]
    public void TestRemoveDugmeBug()
    {
        // Login kao standard_user
        loginPage.EnterUsername("problem_user");
        loginPage.EnterPassword("secret_sauce");
        loginPage.ClickLogin();

        // Dodaj proizvod u korpu
        mainPage.ClickAddToCart();

        // Ukloni proizvod iz korpe više puta
        mainPage.ClickRemoveFromCart();
        mainPage.ClickRemoveFromCart();
        mainPage.ClickRemoveFromCart();

        // Dupli klik na ukloni dugme
        mainPage.DoubleClickRemoveFromCart();

        // Provjera da li je dugme za uklanjanje još uvijek prisutno
        //Assert.Throws<NoSuchElementException>(() =>
        //{
        //    mainPage.ClickRemoveFromCart();
        //});
        IWebElement removeButton = driver.FindElement(By.CssSelector("button[data-test='remove-sauce-labs-backpack']"));
        Assert.That(removeButton.Displayed, Is.True, "Remove button is not displayed.");
    }
}
