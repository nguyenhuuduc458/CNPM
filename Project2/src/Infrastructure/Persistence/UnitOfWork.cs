using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.IRepositories;

namespace Infrastructure.Persistence.Repositories {
    public class UnitOfWork : IUnitOfWork {
        private readonly QuanLyPhongMach _context;

        public UnitOfWork (QuanLyPhongMach context) {
            NhanViens = new NhanVienRepository (context);
            BenhNhans = new BenhNhanRepository (context);
            PhieuKhams = new PhieuKhamRepository(context);
            Benhs = new BenhRepository(context);
            DonThuocs = new DonThuocRepository(context);
            ChiTietDonThuocs = new ChiTietDonThuocRepository(context);
            Thuocs = new ThuocRepository(context);
            VaiTros = new VaiTroRepository(context);
            _context = context;
        }

        public INhanVienRepository NhanViens { get; private set; }

        public IBenhNhanRepository BenhNhans { get; private set; }
        public IPhieuKhamRepository PhieuKhams { get; private set; }
        public IBenhRepository Benhs { get; private set; }

        public IDonThuocRepository DonThuocs { get; private set; }
        public IChiTietDonThuocRepository ChiTietDonThuocs { get; private set; }
        public IThuocRepository Thuocs { get; private set; }

        public IVaiTroRepository VaiTros { get; private set; }
        public int Complete () {
            return _context.SaveChanges ();
        }

        public void Dispose () {
            _context.Dispose ();
        }
    }
}