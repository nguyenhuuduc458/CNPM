using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using AutoMapper;

namespace ApplicationCore.Mapping {
    public class MappingProfile : Profile {
        public MappingProfile () {
            // mapping thuoc 
            CreateMap<Thuoc, ThuocDTO> ();
            CreateMap<ThuocDTO, SaveThuocDTO> ();
            CreateMap<SaveThuocDTO, Thuoc> ();
            // mapping nhanvien 
            CreateMap<NhanVien, SaveNhanVienDTO>();
            CreateMap<SaveNhanVienDTO, NhanVien>();
            //mapping vai tro
            CreateMap<VaiTro, SaveVaiTroDTO>();
            CreateMap<SaveVaiTroDTO, VaiTro>();
            //mapping benh nhan
            CreateMap<BenhNhan, SaveBenhNhanDTO>();
            CreateMap<SaveBenhNhanDTO,BenhNhan>();
            //mapping phieukham
            CreateMap<PhieuKham, SavePhieuKhamDTO>();
            CreateMap<SavePhieuKhamDTO, PhieuKham>();
            // mapping Donthuoc
            CreateMap<DonThuoc, SaveDonThuocDTO>();
            CreateMap<SaveDonThuocDTO, DonThuoc>();
            //mapping CTDT
            CreateMap<ChiTietDonThuoc, SaveChiTietDonThuocDTO>();
            CreateMap<SaveChiTietDonThuocDTO, ChiTietDonThuoc>();
            // mapping benh
            CreateMap<Benh, SaveBenhDTO>();
            CreateMap<SaveBenhDTO, Benh>();


        }

    }
}