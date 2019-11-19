using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using MVCPage.ViewModel;

namespace MVCPage.Services
{
    public interface IThuocService{
        ThuocIndexVM GetThuocIndexVM(string searchString, int pageIndex);
        void Create(Thuoc thuoc);
        void Delete(Thuoc thuoc);
        void Edit(Thuoc thuoc);
    }
}