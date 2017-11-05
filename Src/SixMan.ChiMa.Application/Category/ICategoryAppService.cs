using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using SixMan.ChiMa.Application.Category.Dto;

namespace SixMan.ChiMa.Application.Category
{
    public interface ICategoryAppService
    {
        Task<CategoryDto> Create(CategoryDto input);
        Task Delete(CategoryDto input);
        Task<CategoryDto> Get(CategoryDto input);
        Task<PagedResultDto<CategoryDto>> GetAll(CategoryPagedAndSortedResultRequestDto input);
        Task<CategoryDto> Update(CategoryDto input);
    }
}