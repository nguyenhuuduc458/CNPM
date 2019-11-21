using System.Collections.Generic;
using ApplicationCore.Entities;
using MVCPage.ViewModel;

namespace MVCPage.Services
{
    public interface IBenhServiceView
    {
        BenhIndexVM GetBenhIndexVM( string searchString, string sortOrder, int pageIndex);
        
    }
}