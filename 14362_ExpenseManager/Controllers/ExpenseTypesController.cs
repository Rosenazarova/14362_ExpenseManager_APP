using Microsoft.AspNetCore.Mvc;
using _14362_ExpenseManager.DAL.Models;
using _14362_ExpenseManager.DAL.Repositories;

namespace _14362_ExpenseManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseTypesController : ControllerBase
    {
        private readonly IRepository<ExpenseType> _repository;
        public ExpenseTypesController(IRepository<ExpenseType> repository)
        {
            _repository = repository;
        }

        // GET: api/ExpenseTypes
        [HttpGet]
        public async Task<IEnumerable<ExpenseType>> GetAllTypes() => await _repository.GetAllAsync();

        // GET: api/ExpenseTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExpenseType>> GetTypeById(int id)
        {
            var resultExpenseType = await _repository.GetByIDAsync(id);
            if (resultExpenseType == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(resultExpenseType);
            }
        }

        // PUT: api/ExpenseTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutExpenseType(ExpenseType expenseType)
        {
            await _repository.UpdateAsync(expenseType);
            return NoContent();
        }

        // POST: api/ExpenseTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ExpenseType>> PostExpenseType(ExpenseType expenseType)
        {
            await _repository.AddAsync(expenseType);
            return CreatedAtAction(nameof(GetTypeById), new { id = expenseType.Id }, expenseType);
        }

        // DELETE: api/ExpenseTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpenseType(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
