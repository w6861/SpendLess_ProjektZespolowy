using System;
using SpendLess.Domain.ApiModels;
using SpendLess.Domain.Models;

namespace SpendLess.Domain.Interfaces
{
    public interface ICategoriesRepository
    {
        Task<Category?> GetCategory(Guid categoryId);
        Task<Guid> AddCategory(AddCategory category);
        Task RemoveCategory(Guid categoryId);
        Task<bool> UpdateCategory(Guid categoryId, UpdateCategory updateCategory);
        Task<IList<Category>> GetAllCategories();
    }
}

