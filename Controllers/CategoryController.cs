using HumgNewsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumgNewsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly MyHumgNewsContext _context;
        public CategoryController(MyHumgNewsContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategories(Category danhmuc)
        {
            _context.Categories.Add(danhmuc);
            await _context.SaveChangesAsync();
            return StatusCode(201, danhmuc);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategories(Category danhmuc,int id)
        {
            if(id != danhmuc.CategoryId)
            {
                return BadRequest(); 
            }
            else
            {
                _context.Categories.Update(danhmuc);
                await _context.SaveChangesAsync();
                return NoContent(); 
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeteleCategories(int id)
        {
            var CategoriesDel = _context.Categories.Find(id);
            _context.Categories.Remove(CategoriesDel);
            await _context.SaveChangesAsync();
            return StatusCode(200, CategoriesDel);
        }
        [HttpGet("{id}")]
        public async Task<IEnumerable<Category>> GetCategoriesID (int id)
        {
            return await _context.Categories.Where(x => x.CategoryId == id).ToListAsync();
        }
    }
}
