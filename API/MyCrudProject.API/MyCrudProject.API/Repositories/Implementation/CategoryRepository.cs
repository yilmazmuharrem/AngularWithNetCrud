using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MyCrudProject.API.Data;
using MyCrudProject.API.Models.Domain;
using MyCrudProject.API.Models.DTO;
using MyCrudProject.API.Repositories.Interface;
using System.Threading;

namespace MyCrudProject.API.Repositories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext dbContext;
        public CategoryRepository(ApplicationDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }
        public async Task<Category> CreateAsync(Category category,CancellationToken cancellationToken)
        {


            await dbContext.Categories.AddAsync(category, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
            return category;
        }

        public async Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await dbContext.Categories.ToListAsync(cancellationToken);
        }

        public async Task<Category> GetById(Guid id)
        {
              return await dbContext.Categories.FirstOrDefaultAsync(x=>x.Id ==id);
            }

        public async Task<Category> EditCategoryAsync(Category category, CancellationToken cancellationToken)
        {
          var existingCategory=  await dbContext.Categories.FirstOrDefaultAsync(x=>x.Id ==category.Id);

         if (existingCategory != null)
         {
                dbContext.Entry(existingCategory).CurrentValues.SetValues(category);
                await dbContext.SaveChangesAsync();
                return existingCategory;
         }
         return null;

        }

        public async Task<Category> DeleteCategoryAsync(Guid id, CancellationToken cancellationToken)
        {
         var existing=   await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if (existing == null) return null;

            dbContext.Categories.Remove(existing); await dbContext.SaveChangesAsync();
            return existing;

        }
    }
    }

