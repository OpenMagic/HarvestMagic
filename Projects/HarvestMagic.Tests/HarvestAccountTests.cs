using CommonMagic;
using CommonMagic.DataAnnotations;
using CommonMagic.Reflection;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HarvestMagic.Tests
{
    public class HarvestAccountTests
    {
        [TestClass]
        public class Password
        {
            [TestMethod]
            public void SetGet()
            {
                // Given
                var account = new HarvestAccount();

                // When
                account.Password = "password test";

                // Then
                account.Password.Should().Be("password test");
            }

            [TestMethod]
            public void IsRequired()
            {
                Type<HarvestAccount>
                    .Property(x => x.Password)
                    .IsRequired()
                    .Should().BeTrue();
            }
        }

        [TestClass]
        public class Uri
        {
            [TestMethod]
            public void SetGet()
            {
                // Given
                var account = new HarvestAccount();

                // When
                account.Uri = "Uri test";

                // Then
                account.Uri.Should().Be("Uri test");
            }

            [TestMethod]
            public void IsRequired()
            {
                Type<HarvestAccount>
                    .Property(x => x.Uri)
                    .IsRequired()
                    .Should().BeTrue();
            }

            [TestMethod]
            public void MustBeValidUri()
            {
                Type<HarvestAccount>
                    .Property(x => x.Uri)
                    .IsDecoratedWith<UriAttribute>()
                    .Should().BeTrue();
            }
        }

        [TestClass]
        public class UserName
        {
            [TestMethod]
            public void SetGet()
            {
                // Given
                var account = new HarvestAccount();

                // When
                account.UserName = "UserName test";

                // Then
                account.UserName.Should().Be("UserName test");
            }

            [TestMethod]
            public void IsRequired()
            {
                Type<HarvestAccount>
                    .Property(x => x.UserName)
                    .IsRequired()
                    .Should().BeTrue();
            }
        }
    }
}
