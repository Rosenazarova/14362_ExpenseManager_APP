using _14362_ExpenseManager.DAL.Data;
using _14362_ExpenseManager.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace _14362_ExpenseManager.DAL.Repositories
{
    public class ExpensesRepository : IRepository<Expense>
    {
        private readonly GeneralDBContext _context;

        public ExpensesRepository(GeneralDBContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Expense entity)
        {
            await _context.Expense.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Expense.FindAsync(id);
            if (entity != null)
            {
                _context.Expense.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Expense>> GetAllAsync() => await _context.Expense.Include(t => t.ExpenseType).ToArrayAsync();

        public async Task<Expense> GetByIDAsync(int id)
        {
            return await _context.Expense.Include(t => t.ExpenseType).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task UpdateAsync(Expense entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
