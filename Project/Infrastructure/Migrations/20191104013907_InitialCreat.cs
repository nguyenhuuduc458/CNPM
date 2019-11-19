using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class InitialCreat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Benh",
                columns: table => new
                {
                    MaBenh = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TenBenh = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Benh", x => x.MaBenh);
                });

            migrationBuilder.CreateTable(
                name: "BenhNhans",
                columns: table => new
                {
                    MaBenhNhan = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HoTen = table.Column<string>(nullable: false),
                    GioiTinh = table.Column<string>(nullable: false),
                    NgaySinh = table.Column<DateTime>(nullable: false),
                    DiaChi = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenhNhans", x => x.MaBenhNhan);
                });

            migrationBuilder.CreateTable(
                name: "Thuoc",
                columns: table => new
                {
                    MaThuoc = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TenThuoc = table.Column<string>(nullable: true),
                    SoLuong = table.Column<int>(nullable: false),
                    DonGia = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thuoc", x => x.MaThuoc);
                });

            migrationBuilder.CreateTable(
                name: "VaiTros",
                columns: table => new
                {
                    MaVaiTro = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TenVaiTro = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaiTros", x => x.MaVaiTro);
                });

            migrationBuilder.CreateTable(
                name: "NhanViens",
                columns: table => new
                {
                    MaNhanVien = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MaVaiTro = table.Column<int>(nullable: false),
                    HoTen = table.Column<string>(nullable: false),
                    GioiTinh = table.Column<string>(nullable: false),
                    NgaySinh = table.Column<DateTime>(nullable: false),
                    DiaChi = table.Column<string>(nullable: false),
                    TenDangNhap = table.Column<string>(nullable: true),
                    MatKhau = table.Column<string>(nullable: true),
                    VaiTroMaVaiTro = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanViens", x => x.MaNhanVien);
                    table.ForeignKey(
                        name: "FK_NhanViens_VaiTros_VaiTroMaVaiTro",
                        column: x => x.VaiTroMaVaiTro,
                        principalTable: "VaiTros",
                        principalColumn: "MaVaiTro",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhieuKham",
                columns: table => new
                {
                    MaPhieuKham = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MaBenhNhan = table.Column<int>(nullable: true),
                    MaNhanVien = table.Column<int>(nullable: true),
                    TrieuChung = table.Column<string>(nullable: true),
                    NgayKham = table.Column<DateTime>(nullable: true),
                    BenhNhanMaBenhNhan = table.Column<int>(nullable: true),
                    NhanVienMaNhanVien = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuKham", x => x.MaPhieuKham);
                    table.ForeignKey(
                        name: "FK_PhieuKham_BenhNhans_BenhNhanMaBenhNhan",
                        column: x => x.BenhNhanMaBenhNhan,
                        principalTable: "BenhNhans",
                        principalColumn: "MaBenhNhan",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhieuKham_NhanViens_NhanVienMaNhanVien",
                        column: x => x.NhanVienMaNhanVien,
                        principalTable: "NhanViens",
                        principalColumn: "MaNhanVien",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DonThuoc",
                columns: table => new
                {
                    MaDonThuoc = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MaPhieuKham = table.Column<int>(nullable: true),
                    TongTien = table.Column<double>(nullable: true),
                    PhieuKhamMaPhieuKham = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonThuoc", x => x.MaDonThuoc);
                    table.ForeignKey(
                        name: "FK_DonThuoc_PhieuKham_PhieuKhamMaPhieuKham",
                        column: x => x.PhieuKhamMaPhieuKham,
                        principalTable: "PhieuKham",
                        principalColumn: "MaPhieuKham",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietDonThuoc",
                columns: table => new
                {
                    SoThuTu = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MaThuoc = table.Column<int>(nullable: true),
                    SoLuong = table.Column<int>(nullable: true),
                    ThanhTien = table.Column<double>(nullable: true),
                    MaDonThuoc = table.Column<int>(nullable: true),
                    DonThuocMaDonThuoc = table.Column<int>(nullable: true),
                    ThuocMaThuoc = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietDonThuoc", x => x.SoThuTu);
                    table.ForeignKey(
                        name: "FK_ChiTietDonThuoc_DonThuoc_DonThuocMaDonThuoc",
                        column: x => x.DonThuocMaDonThuoc,
                        principalTable: "DonThuoc",
                        principalColumn: "MaDonThuoc",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietDonThuoc_Thuoc_ThuocMaThuoc",
                        column: x => x.ThuocMaThuoc,
                        principalTable: "Thuoc",
                        principalColumn: "MaThuoc",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonThuoc_DonThuocMaDonThuoc",
                table: "ChiTietDonThuoc",
                column: "DonThuocMaDonThuoc");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonThuoc_ThuocMaThuoc",
                table: "ChiTietDonThuoc",
                column: "ThuocMaThuoc");

            migrationBuilder.CreateIndex(
                name: "IX_DonThuoc_PhieuKhamMaPhieuKham",
                table: "DonThuoc",
                column: "PhieuKhamMaPhieuKham");

            migrationBuilder.CreateIndex(
                name: "IX_NhanViens_VaiTroMaVaiTro",
                table: "NhanViens",
                column: "VaiTroMaVaiTro");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuKham_BenhNhanMaBenhNhan",
                table: "PhieuKham",
                column: "BenhNhanMaBenhNhan");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuKham_NhanVienMaNhanVien",
                table: "PhieuKham",
                column: "NhanVienMaNhanVien");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Benh");

            migrationBuilder.DropTable(
                name: "ChiTietDonThuoc");

            migrationBuilder.DropTable(
                name: "DonThuoc");

            migrationBuilder.DropTable(
                name: "Thuoc");

            migrationBuilder.DropTable(
                name: "PhieuKham");

            migrationBuilder.DropTable(
                name: "BenhNhans");

            migrationBuilder.DropTable(
                name: "NhanViens");

            migrationBuilder.DropTable(
                name: "VaiTros");
        }
    }
}
