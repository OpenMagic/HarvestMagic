using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CommonMagic.Tests
{
    public class TypeTests
    {
        [TestClass]
        public class Property
        {
            [TestMethod]
            public void Should_Be_PropertyInfo_ForRequestedProperty()
            {
                // When
                var propertyInfo = Type<Exception>.Property(x => x.Message);

                // Then
                propertyInfo.Name.Should().Be("Message");
            }

            [TestMethod]
            public void ShouldThrow_ArgumentNullException_When_value_IsNull()
            {
                // When
                Action action = () => Type<Exception>.Property<object>(null);

                // Then
                action.ShouldThrow<ArgumentNullException>()
                    .Subject.Message.EndsWith("Parameter name: value");
            }
        }
    }
}
