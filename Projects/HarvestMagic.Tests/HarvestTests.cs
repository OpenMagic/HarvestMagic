using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace HarvestMagic.Tests
{
    public class HarvestTests
    {
        [TestClass]
        public class Constructor
        {
            [TestMethod]
            public void ShouldThrow_ArgumentNullException_When_account_IsNull()
            {
                // When
                Action action = () => new Harvest(null);

                // Then
                action.ShouldThrow<ArgumentNullException>()
                    .Subject.Message.EndsWith("Parameter name: account");
            }

            [TestMethod]
            public void ShouldThrow_ValidationException_When_account_IsNotValid()
            {
                // Given
                var account = new HarvestAccount();

                // When
                Action action = () => new Harvest(account);

                // Then
                action.ShouldThrow<ValidationException>()
                    .Subject.Message.EndsWith("Parameter name: account");
            }

            [TestMethod]
            public void Should_Freeze_account()
            {
                // Given
                var account = new HarvestAccount() { Password = "fake", Uri = "http://fake.com", UserName = "fake" };

                // When
                var harvest = new Harvest(account);

                // Then
                ((bool)account.GetType().GetField("isFrozen", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(account)).Should().BeTrue();
            }
        }
    }
}
