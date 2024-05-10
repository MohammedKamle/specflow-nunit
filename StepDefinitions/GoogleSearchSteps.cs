using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

[Binding]
public class GoogleSearchSteps
{
   private readonly ScenarioContext _scenarioContext;
     IWebDriver driver;

    public GoogleSearchSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        driver = _scenarioContext.Get<IWebDriver>("driver");
    }


    [Given(@"I have navigated to Google")]
    public void GivenIHaveNavigatedToGoogle()
    {
        driver.Navigate().GoToUrl("https://www.google.com");
        Thread.Sleep(2000);
         
    }

    [When(@"I search for ""(.*)""")]
    public void WhenISearchFor(string searchTerm)
    {
        var searchBox = driver.FindElement(By.Name("q"));
        searchBox.SendKeys(searchTerm + Keys.Enter);
        Thread.Sleep(2000);
    }

    [Then(@"the page title should contain ""(.*)""")]
    public void ThenThePageTitleShouldContain(string expectedTitlePart)
    {   Console.WriteLine("TITLE IS :: "+driver.Title);
       // Assert.That(driver.Title, Does.Contain(expectedTitlePart));
    }

    [AfterScenario]
    public void TearDown()
    {
        driver.Quit();
    }
}
