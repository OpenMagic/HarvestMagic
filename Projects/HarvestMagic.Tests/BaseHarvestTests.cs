using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using HarvestMagic.Core;

namespace HarvestMagic.Tests
{
    [TestClass]
    public abstract class BaseHarvestTests<T> where T : BaseHarvestApi
    {
        [TestMethod]
        public void Constructor_ShouldThrowArgumentNullExceptionWhenAccountIsNull()
        {
            // When
            Action action = () => Activator.CreateInstance(typeof(T), new object[] { null });

            // Then
            action.ShouldThrow<TargetInvocationException>()
                .WithInnerException<ArgumentNullException>()
                .Subject.Message.EndsWith("Parameter name: account");
        }

        [TestMethod]
        public void Constructor_ShouldThrowValidationExceptionWhenAccountIsNotValid()
        {
            // Given
            var account = new HarvestAccount();

            // When
            Action action = () => Activator.CreateInstance(typeof(T), new object[] { account });

            // Then
            action.ShouldThrow<TargetInvocationException>()
                .WithInnerException<ValidationException>()
                .Subject.Message.EndsWith("Parameter name: account");
        }

        [TestMethod]
        public void Constructor_ShouldFreezeAccount()
        {
            // Given
            var account = new HarvestAccount() { Password = "fake", Uri = "http://fake.com", UserName = "fake" };

            // When
            var harvest = Activator.CreateInstance(typeof(T), new object[] { account });

            // Then
            ((bool)account.GetType().GetField("isFrozen", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(account)).Should().BeTrue();
        }

        [TestMethod]
        public void Account_GetSet()
        {
            // Given
            var harvest = (T)Activator.CreateInstance(typeof(T), new object[] { new HarvestAccount() { Password = "fake", Uri = "http://fake.com", UserName = "fake" } });
            var account = new HarvestAccount() { Password = "fake", Uri = "http://fake.com", UserName = "fake" };

            // When
            harvest.Account = account;

            // Then
            harvest.Account.Should().BeSameAs(account);
        }

        [TestMethod]
        public void Account_ShouldThrowArgumentNullExceptionWhenValueIsNull()
        {
            // Given
            var harvest = (T)Activator.CreateInstance(typeof(T), new object[] { new HarvestAccount() { Password = "fake", Uri = "http://fake.com", UserName = "fake" } });

            // When
            Action action = () => harvest.Account = null;

            // Then
            action.ShouldThrow<ArgumentNullException>()
                .Subject.Message.EndsWith("Parameter name: value");
        }

        [TestMethod]
        public void Account_ShouldThrowArgumentNullExceptionWhenValueIsNotValid()
        {
            // Given
            var harvest = (T)Activator.CreateInstance(typeof(T), new object[] { new HarvestAccount() { Password = "fake", Uri = "http://fake.com", UserName = "fake" } });

            // When
            Action action = () => harvest.Account = new HarvestAccount();

            // Then
            action.ShouldThrow<ValidationException>();
        }

        [TestMethod]
        public void Account_SetShouldFreezeValue()
        {
            // Given
            var accountForConstructor = new HarvestAccount() { Password = "fake", Uri = "http://fake.com", UserName = "fake" };
            var accountForProperty = new HarvestAccount() { Password = "fake", Uri = "http://fake.com", UserName = "fake" };
            var harvest = (T)Activator.CreateInstance(typeof(T), new object[] { accountForConstructor });

            // When
            harvest.Account = accountForProperty;

            // Then
            ((bool)accountForProperty.GetType().GetField("isFrozen", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(accountForProperty)).Should().BeTrue();
        }
    }
}
