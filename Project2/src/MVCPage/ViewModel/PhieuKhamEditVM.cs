using System.Collections.Generic;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace MVCPage.ViewModel
{
    public class PhieuKhamEditVM
    {
        public PhieuKhamEditMD PhieuKhamEdit { get; set; }
        public IEnumerable<Benh> listBenh { get; set; }
    }
}