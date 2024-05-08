using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

[Binding]
public class GoogleSearchSteps
{
    private IWebDriver driver;

    [BeforeScenario]
    public void Setup()
    {
        driver = new ChromeDriver();
    }

    [Given(@"I have navigated to Google")]
    public void GivenIHaveNavigatedToGoogle()
    {
        driver.Navigate().GoToUrl("https://www.google.com");
    }

    [When(@"I search for ""(.*)""")]
    public void WhenISearchFor(string searchTerm)
    {
        var searchBox = driver.FindElement(By.Name("q"));
        searchBox.SendKeys(searchTerm + Keys.Enter);
    }

    [Then(@"the page title should contain ""(.*)""")]
    public void ThenThePageTitleShouldContain(string expectedTitlePart)
    {
        Assert.That(driver.Title, Does.Contain(expectedTitlePart));
    }

    [AfterScenario]
    public void TearDown()
    {
        driver.Quit();
    }
}
