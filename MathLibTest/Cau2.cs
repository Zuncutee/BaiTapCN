using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test;

namespace TinhMang
{
    public class Cau2
    {
        private Math math;

        [SetUp]
        public void Setup()
        {
            math = new MathLib();
        }
        [Test]
        public void TinhHieu_VoiMangHopLe_TraVeHieuDung()
        {
            int[] mangNhap = { 10, 5, 8, 3 };
            Mang mang = new Mang(mangNhap);
            int[] ketQua = mang.TinhHieu();
            Assert.AreEqual(new int[] { 5, -3, 5 }, ketQua, "Hiệu các phần tử không đúng.");
        }
    }
}
