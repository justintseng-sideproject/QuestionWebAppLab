using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuestionWebAppLab.DbContexts;
using QuestionWebAppLab.Entities;

namespace QuestionWebAppLab.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionCategoryController : ControllerBase
    {
        private readonly QuestionDbContext _context;

        public QuestionCategoryController(QuestionDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionCategory>>> GetQuestionCategory()
        {
            return await _context.QuestionCategory.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionCategory>> GetQuestionCategory(int id)
        {
            var questionCategory = await _context.QuestionCategory.FindAsync(id);

            if (questionCategory == null)
            {
                return NotFound();
            }

            return questionCategory;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestionCategory(int id, QuestionCategory questionCategory)
        {
            if (id != questionCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(questionCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionCategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<QuestionCategory>> PostQuestionCategory(QuestionCategory questionCategory)
        {
            _context.QuestionCategory.Add(questionCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuestionCategory", new { id = questionCategory.Id }, questionCategory);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<QuestionCategory>> DeleteQuestionCategory(int id)
        {
            var questionCategory = await _context.QuestionCategory.FindAsync(id);
            if (questionCategory == null)
            {
                return NotFound();
            }

            _context.QuestionCategory.Remove(questionCategory);
            await _context.SaveChangesAsync();

            return questionCategory;
        }

        private bool QuestionCategoryExists(int id)
        {
            return _context.QuestionCategory.Any(e => e.Id == id);
        }
    }
}
