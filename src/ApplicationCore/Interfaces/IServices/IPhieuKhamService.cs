using System;
using System.Collections.Generic;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Interfaces.IServices{
    public interface IPhieuKhamService{
        SavePhieuKhamDTO GetPhieuKham(int id);
        IEnumerable<PhieuKhamMD> GetPhieuKhams(string searchString, int MaNhanVien);
        void Create(SavePhieuKhamDTO phieuKham);
        void Edit(SavePhieuKhamDTO phieuKham);
        DateTime GetNgayKham();
        IEnumerable<Benh> GetLoaiBenh();
    }
}