namespace Cau3
{
    public class Tests
    {
        public class XeOTo
        {
            public int Ma { get; set; }
            public string Ten { get; set; }
            public decimal Gia { get; set; }
            public string Ghichu { get; set; }

            public XeOTo(int ma, string ten, decimal gia, string ghichu)
            {
                Ma = ma;
                Ten = ten;
                Gia = gia;
                Ghichu = ghichu;
            }
        }
        public class XeOToService
        {
            private List<XeOTo> _dsXe = new List<XeOTo>();

            public void ThemXe(XeOTo xe)
            {
                _dsXe.Add(xe);
            }

            public void SuaXe(int ma, string ten, decimal gia, string ghichu)
            {
                XeOTo xe = _dsXe.Find(x => x.Ma == ma);
                if (xe != null)
                {
                    xe.Ten = ten;
                    xe.Gia = gia;
                    xe.Ghichu = ghichu;
                }
            }

            public void XoaXe(int ma)
            {
                XeOTo xe = _dsXe.Find(x => x.Ma == ma);
                if (xe != null)
                {
                    _dsXe.Remove(xe);
                }
            }

            public List<XeOTo> LayDanhSachXe()
            {
                return _dsXe;
            }
        }

        [TestFixture]
        public class XeOToServiceTests
        {
            private XeOToService _service;

            [SetUp]
            public void SetUp()
            {
                _service = new XeOToService();
            }

            [Test]
            public void Add()
            {
                XeOTo xe = new XeOTo(1, "Toyota", 50000m, "Xe mới");
                _service.ThemXe(xe);
                Assert.AreEqual(1, _service.LayDanhSachXe().Count);
            }

            [Test]
            public void Edit()
            {
                XeOTo xe = new XeOTo(1, "Toyota", 50000m, "Xe mới");
                _service.ThemXe(xe);
                _service.SuaXe(1, "Toyota Update", 60000m, "Xe cập nhật");
                XeOTo xeSua = _service.LayDanhSachXe().Find(x => x.Ma == 1);
                Assert.AreEqual("Toyota Update", xeSua.Ten);
                Assert.AreEqual(60000m, xeSua.Gia);
                Assert.AreEqual("Xe cập nhật", xeSua.Ghichu);
            }

            [Test]
            public void Delete()
            {
                XeOTo xe = new XeOTo(1, "Toyota", 50000m, "Xe mới");
                _service.ThemXe(xe);
                _service.XoaXe(1);
                Assert.AreEqual(0, _service.LayDanhSachXe().Count);
            }
        }
    }
}
