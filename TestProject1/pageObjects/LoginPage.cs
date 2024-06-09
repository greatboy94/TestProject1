using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TestProject1.pageObjects;

public class LoginPage
{
    
    private IWebDriver driver;

    public LoginPage(IWebDriver driver)
    {
        this.driver = driver;
        PageFactory.InitElements(driver, this);
    }
    
    public void LoginWith(string username, string password)
    {
        driver.FindElement(By.Id("email")).SendKeys(username);
        driver.FindElement(By.Id("password")).SendKeys(password);
        driver.FindElement(By.XPath("//button[@type='submit']")).Click();
    }
}