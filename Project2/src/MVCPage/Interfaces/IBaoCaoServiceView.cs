using System;
using ApplicationCore.Entities;
using MVCPage.ViewModel;

namespace MVCPage.Services
{
    public interface IBaoCaoServiceView
    {
        BaoCaoVM GetIndexBaoCaoVM(int startDate, int endDate, int year,int pageIndex);
    }
}