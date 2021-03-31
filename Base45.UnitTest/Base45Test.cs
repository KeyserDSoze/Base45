using System;
using Xunit;
using System.Text;

namespace Base45.UnitTest
{
    public class Base45Test
    {
        [Fact]
        public void Even()
            => TestPhrase("Hello!");
        [Fact]
        public void Odd()
            => TestPhrase("Hello!!");
        [Fact]
        public void Large()
            => TestPhrase("Hello!! I'm a galaxy guardian and I want to remove the last feature in my backlog because I want to defeat the goliath in my heart on my earth through the hearth");
        private void TestPhrase(string value)
        {
            string returnValue = value.ToBase45();
            Assert.Equal(value, returnValue.FromBase45());
        }
    }
}
