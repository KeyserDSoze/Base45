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
        [Fact]
        public void WrongLength()
        {
            try
            {
                "6BFOXNQG2OAJVUN-8R:*L546/XKPWOSFB60JO DJS4QPR-%2QT45Y7AVD571VX3 43$R71YL423123LF60H9I%5LKB3DJ1OTM7BZGL%0KSVBGZIUSQT35CL6U+QQHPX*OJ+PVC6-S48346-1-P2MED2/D9KD $T2E22R59/9-3AKI63ZM-.Q$76QW60H9GN9Z.DE2K/CJ8RJS$S+6TJYJBKBP:3E0JT*I/$KGZI7AU0OIVZJ%VBKLB8DJI7J/VJ0 JYSJEZIK7B*IJOMI$MI1VC3TCCR6HCRF46NY4LGN+KRA+PE$85FQ/84HHP$AA29D KE5.B7KE0.FBK2ZYSX7E73EEJRN31.:5 VJ5OJSFU9BNA5W+FVUKW%LHPIGP1S:LY*TMMV53RKVN9KKN*H8Y4-O5XS3XUVJZMVOS+*K/LN$VMA JQ.VO1WU412AURD55BR8400GPJ2".FromBase45();
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.Contains("String length is not correct.", ex.Message);
            }
        }
        [Fact]
        public void WrongCharacter()
        {
            try
            {
                "a6BFOXNQG2OAJVUN-8R:*L546/XKPWOSFB60JO DJS4QPR-%2QT45Y7AVD571VX3 43$R71YL423123LF60H9I%5LKB3DJ1OTM7BZGL%0KSVBGZIUSQT35CL6U+QQHPX*OJ+PVC6-S48346-1-P2MED2/D9KD $T2E22R59/9-3AKI63ZM-.Q$76QW60H9GN9Z.DE2K/CJ8RJS$S+6TJYJBKBP:3E0JT*I/$KGZI7AU0OIVZJ%VBKLB8DJI7J/VJ0 JYSJEZIK7B*IJOMI$MI1VC3TCCR6HCRF46NY4LGN+KRA+PE$85FQ/84HHP$AA29D KE5.B7KE0.FBK2ZYSX7E73EEJRN31.:5 VJ5OJSFU9BNA5W+FVUKW%LHPIGP1S:LY*TMMV53RKVN9KKN*H8Y4-O5XS3XUVJZMVOS+*K/LN$VMA JQ.VO1WU412AURD55BR8400GPJ2".FromBase45();
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.Equal("Character a doesn't recognize as valid character.", ex.Message);
            }
        }

        private void TestPhrase(string value)
        {
            string returnValue = value.ToBase45();
            Assert.Equal(value, returnValue.FromBase45());
        }
    }
}
