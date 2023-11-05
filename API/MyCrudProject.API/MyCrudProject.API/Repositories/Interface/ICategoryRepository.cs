using MyCrudProject.API.Models.Domain;
using System.Collections;

namespace MyCrudProject.API.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category,CancellationToken cancellationToken);

        Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken);

        Task<Category?> GetById(Guid id);

        Task<Category?> EditCategoryAsync(Category category, CancellationToken cancellationToken);

        Task<Category?> DeleteCategoryAsync(Guid id, CancellationToken cancellationToken);





    }
}
