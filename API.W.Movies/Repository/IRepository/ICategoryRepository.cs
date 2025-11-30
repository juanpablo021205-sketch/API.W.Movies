using API.W.Movies.DAL.Models;
using System.Threading.Tasks;

namespace API.W.Movies.Repository.IRepository
{
    public interface ICategoryRepository
    {
        Task<ICollection<Category>> GetCategoriesAsync(); //Me retorna una lista de categorias
        Task<Category> GetCategoryAsync(int id); //Me retorna una categoria por su Id
        Task<bool> CategoryExistsByIdAsync(int id); //Me dice si una categoria existe por su Id
        Task<bool> CategoryExistsByNameAsync(string name); //Me dice si una categoria existe por su Nombre
        Task<bool> CreateCategoryAsync(Category category); //Me crea una categoria
        Task<bool> UpdateCategoryAsync(Category category); //Me crea una categoria--puedo actualizar el nombre y la fecha de la ctualizacion
        Task<bool> DeleteCategoryAsync(int id); //Me elimina una categoria
    }
}
