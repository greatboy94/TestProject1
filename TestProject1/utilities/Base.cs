using Allure.NUnit.Attributes;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;

namespace TestProject1;
[Parallelizable(ParallelScope.Children)]

[Allure.NUnit.AllureNUnitAttribute]
public class Base
{
    public IWebDriver driver;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    
    //public IWebDriver driver;
    public string store = "Benutzername oder Passwort nicht korrekts.";
    
    [SetUp]
    public void Setup()
    {
        _logger.Trace("Trace Logger");
        _logger.Debug("Debug Logger");
        _logger.Info("Info Logger");
        _logger.Warn("Warn Logger");
        _logger.Error("Error Logger");
        _logger.Fatal("Fatal Logger");
        
        new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
        driver = new ChromeDriver();

        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl("https://staging.foodpunk.de/login");
        driver.FindElement(
                By.XPath("//button[@class='js-cookie-consent-agree cookie-consent__agree btn  btn-outline-warning']"))
            .Click();
    }
    
    public IWebDriver GetDriver()
    {
        return driver;
    }
    
    public static JsonReader GetDataParser()
    {
        return new JsonReader();
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}