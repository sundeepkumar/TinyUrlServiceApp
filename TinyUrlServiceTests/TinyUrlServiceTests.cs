using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TinyUrlApp;

namespace UnitTestProject1
{

    [TestClass]
    public class TinyUrlServiceTests
    {
        [TestMethod]
        public void CreateShortUrl_ValidUrl_ShouldGenerateShortUrl()
        {
            // Arrange
            var tinyUrlService = new TinyUrlService();

            // Act
            string shortUrl = tinyUrlService.CreateShortUrl("https://www.adroit-tt.com");

            // Assert
            Assert.IsNotNull(shortUrl);
        }

        [TestMethod]
        public void GetLongUrl_ExistingShortUrl_ShouldReturnLongUrl()
        {
            // Arrange
            var tinyUrlService = new TinyUrlService();
            string longUrl = "https://www.adroit-tt.com";
            string shortUrl = tinyUrlService.CreateShortUrl(longUrl);

            // Act
            string retrievedLongUrl = tinyUrlService.GetLongUrl(shortUrl);

            // Assert
            Assert.AreEqual(longUrl, retrievedLongUrl);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Long URL was deleted")]
        public void DeleteShortUrl_ExistingShortUrl_ShouldDeleteShortUrl()
        {
            // Arrange
            var tinyUrlService = new TinyUrlService();
            string shortUrl = tinyUrlService.CreateShortUrl("https://www.adroit-tt.com");

            // Act
            tinyUrlService.DeleteShortUrl(shortUrl);

            // Assert
            tinyUrlService.GetLongUrl(shortUrl);

        }

        [TestMethod]
        public void GetClickCount_ExistingShortUrl_ShouldReturnClickCount()
        {
            // Arrange
            var tinyUrlService = new TinyUrlService();
            string shortUrl = tinyUrlService.CreateShortUrl("https://www.adroit-tt.com");

            // Act
            int initialClickCount = tinyUrlService.GetClickCount(shortUrl);

            // Assert
            Assert.AreEqual(0, initialClickCount);
        }

        [TestMethod]
        public void CreateShortUrl_CustomShortUrl_ShouldUseCustomShortUrl()
        {
            // Arrange
            var tinyUrlService = new TinyUrlService();

            // Act
            string customShortUrl = "custom";
            string shortUrl = tinyUrlService.CreateShortUrl("https://www.adroit-tt.com", customShortUrl);

            // Assert
            Assert.AreEqual(customShortUrl, shortUrl);
        }

    }
}