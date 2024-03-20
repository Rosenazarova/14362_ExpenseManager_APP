using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _14362_ExpenseManager.DAL.Data;
using _14362_ExpenseManager.DAL.Models;
using _14362_ExpenseManager.DAL.Repositories;

namespace _14362_ExpenseManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IRepository<Expense> _expenseRepository;
        public ExpensesController(IRepository<Expense> expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        // GET: api/Expenses
        [HttpGet]
        public async Task<IEnumerable<Expense>> GetAll() => await _expenseRepository.GetAllAsync();

        // GET: api/Expenses/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var expense = await _expenseRepository.GetByIDAsync(id);
            return expense == null ? NotFound() : Ok(expense);
        }

        // PUT: api/Expenses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Expense expense)
        {
            await _expenseRepository.UpdateAsync(expense);
            return NoContent();
        }

        // POST: api/Expenses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Expense>> Create(Expense expense)
        {
            await _expenseRepository.AddAsync(expense);
            return Ok(expense);
        }

        // DELETE: api/Expenses/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _expenseRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
