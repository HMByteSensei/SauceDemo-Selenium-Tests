using NUnit.Framework;
using OpenQA.Selenium;

[TestFixture]
public class LoginNeispravanUsernameneispravanTest
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
    public void TestInvalidUsername()
    {
        // Navigate to login page
        loginPage.GoToPage();

        // Attempt to login with incorrect username and correct password
        loginPage.Login("standard_use", "secret_sauce");

        // Assert that the error message is displayed
        string errorMessage = loginPage.GetErrorMessage();
        Assert.That(errorMessage, Is.EqualTo("Epic sadface: Username and password do not match any user in this service"), "Error message mismatch for incorrect username.");
    }
}
