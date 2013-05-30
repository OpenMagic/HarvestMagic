using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CommonMagic.Reflection.Tests
{
    public class ObjectExtensionsTests
    {
        [TestClass]
        public class Property
        {
            [TestMethod]
            public void Should_Be_PropertyInfo_ForRequestedProperty()
            {
                // Given
                var obj = new Exception();

                // When
                var propertyInfo = obj.Property(x => x.Message);

                // Then
                propertyInfo.Name.Should().Be("Message");
            }

            [TestMethod]
            public void ShouldThrow_ArgumentNullException_When_obj_IsNull()
            {
                // Given
                Exception obj = null;

                // When
                Action action = () => obj.Property<Exception, object>(null);

                // Then
                action.ShouldThrow<ArgumentNullException>()
                    .Subject.Message.EndsWith("Parameter name: obj");
            }

            [TestMethod]
            public void ShouldThrow_ArgumentNullException_When_property_IsNull()
            {
                // Given
                var obj = new Exception();

                // When
                Action action = () => obj.Property<Exception, object>(null);

                // Then
                action.ShouldThrow<ArgumentNullException>()
                    .Subject.Message.EndsWith("Parameter name: property");
            }
        }
    }
}
