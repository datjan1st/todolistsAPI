using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using todolistsAPI.Database;
using todolistsAPI.DataCntxt;
using todolistsAPI.DTOs;


namespace todolistsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly dataContext _context;

        public CategoryController(dataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<List<Category>> Get()
        {
            var GetAllLists = (from c in _context.category
                               join t in _context.todoList on c.CategoryName equals t.CategoryName
                               select new
                               {
                                   c.CategoryName,
                                   t.TodoListId,
                                   t.UserId,
                                   t.TaskId,
                                   t.Title,
                                   t.Status,
                                   t.Description
                               }
                ).ToList();
            return Ok(GetAllLists);
        }

        [HttpGet("GetCategoryByI/{categoryId}")]
        public async Task<ActionResult<List<Category>>> GetbyCategoryId(int categoryId)
        {
            var GetCategoryById = await _context.category
                .Where(u => u.CategoryId == categoryId)
                .Include(u => u.TodoList)
                .ToListAsync();
            if (GetCategoryById == null)
                return BadRequest("Category id not found.");
            return Ok(GetCategoryById);
        }

        [HttpGet("GetbyCategoryName/{categoryName}")]
        public async Task<ActionResult<List<Category>>> GetbyCategoryName(string categoryName)
        {
            var GetCategoryByName = _context.todoList.Where(u => u.CategoryName == categoryName).ToList();
            return Ok(GetCategoryByName);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> addnewcategory(CategoryDTO newCategory)
        {
            var AddNewCategory = new Category()
            {
                CategoryName = newCategory.CategoryName
            };
            _context.category.Add(AddNewCategory);
            await _context.SaveChangesAsync();
            return Ok(AddNewCategory);
        }

        [HttpDelete("{deleteCategory}")]
        public async Task<ActionResult<List<Category>>> deleteCategory(int deleteCategory)
        {
            
            var DeleteCategory = await _context.category.FindAsync(deleteCategory);
            if (DeleteCategory == null)
                return BadRequest("Category not found.");
            _context.category.Remove(DeleteCategory);
            await _context.SaveChangesAsync();
            return Ok(await _context.category.ToListAsync());

        }

        [HttpPut]
        public async Task<ActionResult<List<Category>>> UpdateCategory(CategoryDTO UpdateCategory)
        {

            var updateCategory = await _context.category.FindAsync(UpdateCategory.CategoryId);
            if (updateCategory == null)
                return BadRequest("Category not found.");
            updateCategory.CategoryName = UpdateCategory.CategoryName;
            await _context.SaveChangesAsync();
            return Ok(await _context.category.ToListAsync());

        }

    }
}
