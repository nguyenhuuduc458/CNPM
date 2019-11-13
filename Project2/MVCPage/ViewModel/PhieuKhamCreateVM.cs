using System.Collections.Generic;
using ApplicationCore.Entities;

namespace MVCPage.ViewModel
{
    public class PhieuKhamCreateVM
    {
        public PhieuKham PhieuKhams { get; set; }
        public IEnumerable<Benh> listTenBenh { get; set; }
    }
}