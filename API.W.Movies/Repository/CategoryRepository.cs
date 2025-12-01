using API.W.Movies.DAL;
using API.W.Movies.DAL.Models;
using API.W.Movies.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace API.W.Movies.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private  readonly ApplicationDbContext _Context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _Context = context;
        }

        public async Task<bool> CategoryExistsByIdAsync(int id)
        {
            return await _Context.Categories
                .AsNoTracking()
                .AnyAsync(c => c.Id == id);
        }

        public async Task<bool> CategoryExistsByNameAsync(string name)
        {
            return await _Context.Categories
             .AsNoTracking()
             .AnyAsync(c => c.Name == name);
        }

        public async Task<bool> CreateCategoryAsync(Category category)
        {
           category.CreatedDate = DateTime.UtcNow;
            await _Context.Categories.AddAsync(category);
            return await SaveAsync();
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await GetCategoryAsync(id);//Primero consulto si existe la categoria

            if (category == null)
            {
                return false; //la categoria no existe
            }

            _Context.Categories.Remove(category);
            return await SaveAsync();
        }

        public async Task<ICollection<Category>> GetCategoriesAsync()
        {
            var categories = await _Context.Categories
                .AsNoTracking()
                .OrderBy(c => c.Name)//Ascending order
                .ToListAsync();

            return categories;
        }

        public async Task<Category> GetCategoryAsync(int id) //async y el await
        {
            return await _Context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id); //lambda expressions
        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            category.ModifiedDate = DateTime.UtcNow;
            _Context.Categories.Update(category);
            return await SaveAsync();
        }
        private async Task<bool> SaveAsync()
        {
            return await _Context.SaveChangesAsync() >= 0 ? true : false;
        }
    }
}
