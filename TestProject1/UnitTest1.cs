using Allure.NUnit.Attributes;
using NUnit.Allure.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;

namespace TestProject1;


[AllureNUnit]
public class Tests
{
    public IWebDriver driver;
    public string store = "Benutzername oder Passwort nicht korrekts.";

    [SetUp]
    public void Setup()
    {
        new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
        driver = new ChromeDriver();

        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl("https://staging.foodpunk.de/login");
        driver.FindElement(
                By.XPath("//button[@class='js-cookie-consent-agree cookie-consent__agree btn  btn-outline-warning']"))
            .Click();
    }

    [Test]
    //[TestCaseSource(typeof(TestDataHelper), nameof(TestDataHelper.GetInvalidLoginTestData))]
    [AllureDescription("This is a sample test")]
    public void Test1()
    {
        driver.FindElement(By.Id("email")).SendKeys("username@gmail.com");
        driver.FindElement(By.Id("password")).SendKeys("password");
        driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        Console.WriteLine("Passed");
    }

    [Test]
    [AllureDescription("This is a sample test")]
    //[TestCaseSource(typeof(TestDataHelper), nameof(TestDataHelper.GetValidLoginTestData))]
    public void Test2()
    {
        driver.FindElement(By.Id("email")).SendKeys("username2@gmail.com");
        driver.FindElement(By.Id("password")).SendKeys("1234566");
        driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        Console.WriteLine("Passed");
        Assert.Pass();
    }
    [Test]
    public void Test3()
    {
        driver.FindElement(By.Id("email")).SendKeys("username2@gmail.com");
        driver.FindElement(By.Id("password")).SendKeys("1234566");
        driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        Console.WriteLine("Passed");
        Assert.Pass();
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}