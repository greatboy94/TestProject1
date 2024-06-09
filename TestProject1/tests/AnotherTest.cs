using TestProject1.pageObjects;

namespace TestProject1.tests;

public class AnotherTest : Base
{
    [Test]
    [TestCaseSource(typeof(JsonReader), nameof(JsonReader.GetValidLoginTestData))]
    public void ValidLogin(string username, string password)
    {
        LoginPage loginPage = new LoginPage(GetDriver());
        loginPage.LoginWith(username, password);
    }
}