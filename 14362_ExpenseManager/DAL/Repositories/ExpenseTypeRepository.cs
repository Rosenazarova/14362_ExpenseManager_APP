using _14362_ExpenseManager.DAL.Data;
using _14362_ExpenseManager.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace _14362_ExpenseManager.DAL.Repositories
{
    public class ExpenseTypeRepository : IRepository<ExpenseType>
    {
        private readonly GeneralDBContext _context;

        public ExpenseTypeRepository(GeneralDBContext context)
        {
            _context = context;
        }
        public async Task AddAsync(ExpenseType entity)
        {
            await _context.ExpenseType.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.ExpenseType.FindAsync(id);
            if (entity != null)
            {
                _context.ExpenseType.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ExpenseType>> GetAllAsync() => await _context.ExpenseType.ToArrayAsync();

        public async Task<ExpenseType> GetByIDAsync(int id) => await _context.ExpenseType.FindAsync(id);

        public async Task UpdateAsync(ExpenseType entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
