using AnonymousFeedback.Domian.IUnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousFeedback.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        private IDbContextTransaction _transaction;

        public UnitOfWork(ApplicationDbContext context)
        {
            _db=context;
        }

        public async Task BeginTransaction()
        {
            _transaction = await _db.Database.BeginTransactionAsync();
        }

        public async Task<int> Complete()
        {
            return await _db.SaveChangesAsync();
        }
        public async Task CommitTransaction()
        {
            await _transaction.CommitAsync();
        }
        public async Task RollbackTransaction()
        {
            await _transaction.RollbackAsync();
        }

        public async Task DisposeTransaction()
        {
            await _transaction.DisposeAsync();
        }
        public bool IsTransactionStarted()
        {
            return _transaction != null;
        }
        public async Task<int> ExecuteQuery(string query)
        {
            return await _db.Database.ExecuteSqlRawAsync(query);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task<int> ExecuteSqlCommand(FormattableString query)
        {
            return await _db.Database.ExecuteSqlInterpolatedAsync(query);
        }
    }
}
