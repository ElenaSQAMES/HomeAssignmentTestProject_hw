using NUnit.Framework;
using HomeAssignmentTestProject.Resources.Pages;

namespace HomeAssignmentTestProject.Tests
{
    [TestFixture]
    public class WikiAutoTests 
    {
        
        [Test]
        public void CompareDataTest()
        {
            // Arrange
            var dataFromApi = WikiAutomationTextMethods.GetDataFromApi();
            var wikiAutoPage = WikiAutoPageMethods.Instance;

            // Act
            wikiAutoPage.Navigate();
            var dataFromUi = wikiAutoPage.GetDataFromPage();

            // Assert
            var notFoundInUi = dataFromApi
                .Where(item =>
                    !dataFromUi.Keys.Any(key => string.Equals(key, item.Key, StringComparison.OrdinalIgnoreCase)))
                .ToList();

            Assert.That(notFoundInUi, Is.Empty,
                $"Word occurrences from API call not found in UI parsing:{Environment.NewLine}{string.Join(Environment.NewLine, notFoundInUi)}");
            Thread.Sleep(2000);
            SeleniumHolder.Instance.CloseBrowser();
                
        }
    }
}

