using CommonMagic.DataAnnotations;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonMagic.Tests.DataAnnotations
{
    [TestClass]
    public class UriAttributeTests
    {
        [TestClass]
        public class IsValid
        {
            [TestMethod]
            public void Should_BeTrue_When_value_IsValidUri()
            {
                IsValid_For("http://example.com").Should().BeTrue();
            }

            [TestMethod]
            public void Should_BeFalse_When_value_IsNotValidUri()
            {
                IsValid_For("an invalid url").Should().BeFalse();
                IsValid_For(2).Should().BeFalse();
            }

            [TestMethod]
            public void Should_BeTrue_When_value_IsNull()
            {
                IsValid_For(null).Should().BeTrue();
            }

            [TestMethod]
            public void Should_BeTrue_When_value_IsWhitespace()
            {
                IsValid_For("").Should().BeTrue();
            }

            private bool IsValid_For(object uri)
            {
                return (new UriAttribute()).IsValid(uri);
            }
        }
    }
}
