namespace Cau2
{
    public class Mang
    {
        private int[] _mang;

        public  Mang(int[] mang)
        {
            if (mang.Length != 4)
            {
                throw new ArgumentException("Mảng phải có đúng 4 phần tử.");
            };
            _mang = mang;
        }
        public int[] TinhHieu()
        {
            int[] hieu = new int[_mang.Length - 1];
            for (int i = 0; i < _mang.Length - 1; i++)
            {
                hieu[i] = _mang[i] - _mang[i + 1];
            }
            return hieu;
        }
    }
    [TestFixture]
    public class MangTests
    {
        [Test]
        public void TinhMang()
        {
            int[] mangNhap = { 10, 5, 8, 3 };
            Mang mang = new Mang(mangNhap);
            int[] ketQua = mang.TinhHieu();
            Assert.AreEqual(new int[] { 5, -3, 5 }, ketQua, "Hiệu các phần tử không đúng.");
        }
    }
}