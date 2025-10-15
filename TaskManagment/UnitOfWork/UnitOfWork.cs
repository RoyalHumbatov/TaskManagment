using Microsoft.EntityFrameworkCore;
using TaskManagment.DataContext;

namespace TaskManagment.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public void Commit()
        {
             _context.SaveChanges();
        }

        public async void CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
