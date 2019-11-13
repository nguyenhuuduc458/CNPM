using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces.IRepositories
{
    public interface IDonThuocRepository : IRepository<DonThuoc>
    {
        void CapNhatTrangThaiPhieuKham(int MaPhieuKham);
    }
}