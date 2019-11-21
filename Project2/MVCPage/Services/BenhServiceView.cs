using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.IServices;
using MVCPage.ViewModel;

namespace MVCPage.Services
{
    public class BenhServiceView : IBenhServiceView
    {
        private int pageSize = 3;
        private IBenhService _service;
        public BenhServiceView(IBenhService service){
            _service = service;
        }
        public BenhIndexVM GetBenhIndexVM(string searchString,string sortOrder, int pageIndex)
        {
            int count;
            var benh = _service.GetBenhs(searchString, sortOrder, pageIndex, pageSize, out count);
            return new BenhIndexVM {
                Benhs = new PaginatedList<SaveBenhDTO>(benh, pageIndex, pageSize,count)
            };
        }

    }
}