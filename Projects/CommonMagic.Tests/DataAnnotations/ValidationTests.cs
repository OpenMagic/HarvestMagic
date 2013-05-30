using CommonMagic.DataAnnotations;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ComponentModel.DataAnnotations;

namespace CommonMagic.Tests.DataAnnotations
{
    public class ValidationTests
    {
        [TestClass]
        public class Validate
        {
            [TestMethod]
            public void ShouldThrow_ArgumentNullException_When_value_IsNull()
            {
                // When
                Action action = () => Validation.Validate<object>(null);

                // Then
                action.ShouldThrow<ArgumentNullException>()
                    .Subject.Message.EndsWith("Parameter name: value");
            }

            [TestMethod]
            public void ShouldThrow_ValidationException_When_value_IsNotValid()
            {
                // Given
                var invalidObject = new TestClass();

                // When
                Action action = () => Validation.Validate(invalidObject);

                // Then
                action.ShouldThrow<ValidationException>();
            }

            [TestMethod]
            public void Should_BeSameAs_value_When_value_IsValid()
            {
                // Given
                var validObject = new TestClass() { Required = "required property" };

                // When
                var result = validObject.Validate();

                // Then
                result.Should().BeSameAs(validObject);
            }
        }

        public class TestClass
        {
            [Required]
            public string Required { get; set; }
        }
    }
}
