using System;
using Microsoft.EntityFrameworkCore;
using SpendLess.Domain.ApiModels;
using SpendLess.Domain.Interfaces;
using SpendLess.Domain.Models;
using SpendLess.Infrastructure;
using SpendLess.Infrastructure.Models;

namespace SpendLess.Infrastructure.Repositories
{

    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly SpendLessContext _context;

        public CategoriesRepository(SpendLessContext context)
        {
            _context = context;
        }

        public async Task<Guid> AddCategory(AddCategory category)
        {
            var newCategory = new DbCategory { CategoryId = Guid.NewGuid(), Name = category.Name };
            await _context.Categories.AddAsync(newCategory);
            await _context.SaveChangesAsync();
            return newCategory.CategoryId;
        }

        public async Task<IList<Category>> GetAllCategories()
        {
            return await _context.Categories.Select(c => new Category { CategoryId = c.CategoryId, Name = c.Name })
                                            .OrderBy(c => c.Name)
                                            .AsNoTracking()
                                            .ToListAsync();
        }

        public async Task<Category?> GetCategory(Guid categoryId)
        {
            return await _context.Categories.Select(c => new Category { CategoryId = c.CategoryId, Name = c.Name })
                                            .AsNoTracking()
                                            .FirstOrDefaultAsync(c => c.CategoryId == categoryId);
        }

        public async Task RemoveCategory(Guid categoryId)
        {
            var categoryToRemove = await _context.Categories.FindAsync(categoryId);
            if (categoryToRemove is null)
            {
                throw new Exception($"Category {categoryId} not found");
            }

            var removeContext = _context.Remove(categoryToRemove);
            await removeContext.Context.SaveChangesAsync();
            return;
        }

        public async Task<bool> UpdateCategory(Guid categoryId, UpdateCategory updateCategory)
        {
            var categoryToUpdate = await _context.Categories.FindAsync(categoryId);
            if (categoryToUpdate is null)
            {
                throw new Exception($"Category {categoryId} not found");
            }

            categoryToUpdate.Name = updateCategory.Name;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

