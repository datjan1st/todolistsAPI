using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todolistsAPI.Entities;
using todolistsAPI.Data;
using todolistsAPI.DTOs;


namespace todolistsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly DataContext _context;

        public CategoryController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string? name)
        {
            var query = _context.Category
                .Include(x => x.TodoLists)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(x => x.CategoryName.Contains(name));
            }

            var items = await query
                .Select(c => new CategoryResponseDTO
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName,
                    TodoListDTOs = c.TodoLists.Select(t => new TodoListResponseDTO
                    {
                        Description = t.Description,
                        Number = t.Number,
                        Status = t.Status,
                        TaskId = t.TaskId,
                        Title = t.Title,
                        TodoListId = t.TodoListId,
                        UserId = t.UserId
                    }).ToList()
                })
                .ToListAsync();
            return Ok(items);
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetById(int categoryId)
        {
            var category = await _context.Category
                .Include(u => u.TodoLists)
                .Where(u => u.CategoryId == categoryId)
                .FirstOrDefaultAsync();
            if (category == null)
                return BadRequest("Category id not found.");

            return Ok(new CategoryResponseDTO
            {
                CategoryId = categoryId,
                CategoryName = category.CategoryName,
                TodoListDTOs = category.TodoLists.Select(t => new TodoListResponseDTO
                {
                    Description = t.Description,
                    Number = t.Number,
                    Status = t.Status,
                    TaskId = t.TaskId,
                    Title = t.Title,
                    TodoListId = t.TodoListId,
                    UserId = t.UserId
                }).ToList()
            });
        }

        [HttpPost]
        public async Task<ActionResult<Category>> Create(CategoryRequestDTO categoryRequestDTO)
        {
            var categoryToCreate = new Category()
            {
                CategoryName = categoryRequestDTO.CategoryName
            };

            _context.Category.Add(categoryToCreate);
            await _context.SaveChangesAsync();
            return Ok(new CategoryResponseDTO
            {
                CategoryId = categoryToCreate.CategoryId,
                CategoryName = categoryToCreate.CategoryName
            });
        }

        [HttpPut]
        public async Task<IActionResult> Update(CategoryRequestDTO categoryRequestDTO)
        {

            var categoryToUpdate = await _context.Category.FindAsync(categoryRequestDTO.CategoryId);
            if (categoryToUpdate == null)
                return BadRequest("Category not found.");

            categoryToUpdate.CategoryName = categoryRequestDTO.CategoryName;
            await _context.SaveChangesAsync();
            return Ok(new CategoryResponseDTO
            {
                CategoryId = categoryToUpdate.CategoryId,
                CategoryName = categoryToUpdate.CategoryName,
                TodoListDTOs = categoryToUpdate.TodoLists != null
                    ? categoryToUpdate.TodoLists.Select(t => new TodoListResponseDTO
                    {
                        Description = t.Description,
                        Number = t.Number,
                        Status = t.Status,
                        TaskId = t.TaskId,
                        Title = t.Title,
                        TodoListId = t.TodoListId,
                        UserId = t.UserId
                    }).ToList()
                    : new List<TodoListResponseDTO>()
            });

        }

        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> Delete(int categoryId)
        {
            var categoryToDelete = await _context.Category.FindAsync(categoryId);
            if (categoryToDelete == null)
                return BadRequest("Category not found.");

            _context.Category.Remove(categoryToDelete);
            await _context.SaveChangesAsync();
            return Ok();

        }
    }
}
