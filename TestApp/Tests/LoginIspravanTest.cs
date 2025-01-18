using NUnit.Framework;
using OpenQA.Selenium;


[TestFixture]
public class LoginIspravanTest
{
    private IWebDriver driver;
    private LoginPage loginPage;

    [SetUp]
    public void SetUp()
    {
        driver = DriverManager.GetDriver();
        loginPage = new LoginPage(driver);
    }

    [TearDown]
    protected void TearDown()
    {
        driver.Quit();
        driver.Dispose();
        DriverManager.QuitDriver();
    }

    [Test]
    public void TestValidLogin()
    {
        // Navigate to login page
        loginPage.GoToPage();

        // Perform login
        loginPage.Login("standard_user", "secret_sauce");

        // Add an assertion to verify login was successful
        Assert.That(driver.Url.Contains("inventory"), Is.True, "Login was not successful.");
    }
}