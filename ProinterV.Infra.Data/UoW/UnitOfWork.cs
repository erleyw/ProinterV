using ProinterV.Domain.Interfaces;
using ProinterV.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProinterV.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbProinterContext _context;

        public UnitOfWork(DbProinterContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
