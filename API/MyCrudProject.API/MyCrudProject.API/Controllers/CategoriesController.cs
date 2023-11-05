using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCrudProject.API.Data;
using MyCrudProject.API.Models.Domain;
using MyCrudProject.API.Models.DTO;
using MyCrudProject.API.Repositories.Implementation;
using MyCrudProject.API.Repositories.Interface;
using System.Runtime.InteropServices;

namespace MyCrudProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoriesController(ICategoryRepository _categoryRepository)
        {
            this.categoryRepository = _categoryRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestDto request, CancellationToken cancellationToken)
        {
            var category = new Category
            {

                Name = request.Name,
                UrlHandle = request.UrlHandle,
            };

            await categoryRepository.CreateAsync(category, cancellationToken);
            var response = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle,
            };

            return Ok(response);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCategories(CancellationToken cancellationToken)
        {
            var categories = await categoryRepository.GetAllAsync(cancellationToken);

            var response = new List<CategoryDto>();

            foreach (var category in categories)
            {
                response.Add(new CategoryDto
                {
                    Id = category.Id,
                    Name = category.Name,
                    UrlHandle = category.UrlHandle,
                });
            }
            return Ok(response);
        }


        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] Guid id)
        {
            var isExist = await categoryRepository.GetById(id);

            if (isExist is null) return NotFound();

            var response = new CategoryDto
            {
                Id = isExist.Id,
                Name = isExist.Name,
                UrlHandle = isExist.UrlHandle,
            };
            return Ok(response);
        }


        [HttpPost]
        [Route("{id:Guid}")]
        public async Task<IActionResult> EditCategory([FromRoute] Guid id, UpdateCategoryRequestDto request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Id = id,
                Name = request.Name,
                UrlHandle = request.UrlHandle,
            };
            category = await categoryRepository.EditCategoryAsync(category, cancellationToken);

            if (category == null)
            {
                return NotFound();
            }

            var response = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle,

            };

            return Ok(response);
        }




        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var category = await categoryRepository.DeleteCategoryAsync(id, cancellationToken);

            if (category is null) return NotFound();


            var response = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle,
            };
            return Ok(response);
        }
    }
}
