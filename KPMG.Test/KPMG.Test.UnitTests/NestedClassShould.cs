using FluentAssertions;
using KPMG_Test;
using System;
using System.Collections.Generic;
using Xunit;

namespace KPMG.Test.UnitTests
{
    public class NestedClassShould
    {
        private Nested nestedObj;
        public NestedClassShould()
        {
            nestedObj = new Nested("x", new Nested("y", new Nested("z", "a")));
        }

        [Fact]
        public void ReturnKeys_WhenGetKeysMethodIscalled()
        {
            //Given - Input is ready
            var expected = new List<string> { "x", "y", "z"};

            //When
            var actualKeys = nestedObj.GetKeys();

            //Then
            actualKeys.Should().BeEquivalentTo(expected);

        }

        [Fact]
        public void ReturnValue_WhenGetValueMethodIscalled()
        {
            //Given - Input is ready
            var expected = "a";

            //When
            var actualValue = nestedObj.GetValue();

            //Then
            actualValue.Should().Be(expected);
        }

        [Fact]
        public void ReturnSpecificValue_WhenGetValueByKeyMethodIscalled()
        {
            //Given - Input is ready
            var expected = new Nested("z","a");

            //When
            var actualValue = nestedObj.GetValueByKey("y");

            //Then
            ((Nested)actualValue).Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void ReturnSpecificStringValue_WhenGetValueByKeyMethodIscalled()
        {
            //Given - Input is ready
            var expected = "a";

            //When
            var actualValue = nestedObj.GetValueByKey("z");

            //Then
            actualValue.Should().Be(expected);
        }

        [Fact]
        public void ThrowException_WhenGetValueByKeyMethodIscalled_WithInvalidKey()
        {            
            //When
            Assert.Throws<InvalidOperationException>( () => nestedObj.GetValueByKey("p"));
        }
    }
}
