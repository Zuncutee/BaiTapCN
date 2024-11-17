namespace Cau1
{
    public class Tests
    {  
        [TestCase(0, ExpectedResult = true)]
        [TestCase(4, ExpectedResult = true)]
        [TestCase(5, ExpectedResult = false)]
        [TestCase(6, ExpectedResult = true)]
        [TestCase(18, ExpectedResult = true)]
        [TestCase(10, ExpectedResult = true)]
        [TestCase(9, ExpectedResult = false)]
        [TestCase(21, ExpectedResult = false)]
        [TestCase(25, ExpectedResult = false)]
        [TestCase(40, ExpectedResult = true)]
        public bool SoChiaCho2(int a)
        {
            return a % 2 == 0;
        }   
    }
}
