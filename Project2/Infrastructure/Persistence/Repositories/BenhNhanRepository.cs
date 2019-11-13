using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.IRepositories;

namespace Infrastructure.Persistence.Repositories
{
    public class BenhNhanRepository : IBenhNhanRepository
    {
        private readonly QuanLyPhongMach _context;
        public BenhNhanRepository(QuanLyPhongMach context){
            _context = context;
        }
        public void Add(BenhNhan Entity)
        {
            _context.Add(Entity);
        }

        public void AddRange(IEnumerable<BenhNhan> Entities)
        {
            _context.AddRange(Entities);
        }

        public IEnumerable<BenhNhan> Find(Expression<Func<BenhNhan, bool>> predicate)
        {
            return _context.BenhNhans.Where(predicate);
        }

        public IEnumerable<BenhNhan> GetAll()
        {
            return _context.BenhNhans.ToList();
        }

        public BenhNhan GetById(int id)
        {
            return _context.BenhNhans.Find(id);
        }
        public void Remove(BenhNhan Entity)
        {
            _context.Remove(Entity);
        }

        public void RemoveRange(IEnumerable<BenhNhan> Entities)
        {
            _context.RemoveRange(Entities);
        }

        public void Update(BenhNhan Entity)
        {
            _context.Update(Entity);
        }
    }
}