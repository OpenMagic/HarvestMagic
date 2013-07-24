using System.Reflection;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenMagic.DataAnnotations;
using OpenMagic.Reflection;

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

        [TestClass]
        public class Freeze
        {
            [TestMethod]
            public void ChangesAllPublicPropertiesToFrozen()
            {
                // Given
                var account = new HarvestAccount();

                // When
                account.Freeze();

                // Then
                IsFrozen(account, account.Property(x => x.Password), "fake password").Should().BeTrue();
                IsFrozen(account, account.Property(x => x.Uri), "http://fakeuri.com").Should().BeTrue();
                IsFrozen(account, account.Property(x => x.UserName), "fake user name").Should().BeTrue();
            }

            private bool IsFrozen(object obj, PropertyInfo propertyInfo, string value)
            {
                try
                {
                    propertyInfo.SetValue(obj, value, null);
                }
                catch (TargetInvocationException ex)
                {
                    if (ex.InnerException.Message == "Attempted to modify a frozen instance")
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
