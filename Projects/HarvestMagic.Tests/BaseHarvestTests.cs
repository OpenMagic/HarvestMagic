using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace HarvestMagic.Tests
{
    [TestClass]
    public abstract class BaseHarvestTests<T>
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
            Assert.Inconclusive("todo");
        }

        [TestMethod]
        public void Account_ShouldThrowArgumentNullExceptionWhenValueIsNull()
        {
            Assert.Inconclusive("todo");
        }

        [TestMethod]
        public void Account_ShouldThrowArgumentNullExceptionWhenValueIsNotValid()
        {
            Assert.Inconclusive("todo");
        }

        [TestMethod]
        public void Account_SetShouldFreezeValue()
        {
            Assert.Inconclusive("todo");
        }
    }
}
