using System.Collections.Generic;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace MVCPage.ViewModel
{
    public class PhieuKhamCreateVM
    {
        public PhieuKhamEditMD PhieuKhams { get; set; }
        public IEnumerable<Benh> listTenBenh { get; set; }
    }
}