using TestProject1.pageObjects;

namespace TestProject1.tests;

public class AnotherTest : Base
{
    [Test]
    [TestCaseSource(typeof(JsonReader), nameof(JsonReader.GetInvalidLoginTestData))]
    public void InvalidLogin(string username, string password)
    {
        LoginPage loginPage = new LoginPage(GetDriver());
        loginPage.LoginWith(username, password);
    }
}