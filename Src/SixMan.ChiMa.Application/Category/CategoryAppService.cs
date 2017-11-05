using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using SixMan.ChiMa.Application.Category.Dto;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Linq;
using Abp.Domain.Uow;
using Abp;
using Abp.Extensions;
using System.Linq.Dynamic.Core;
using Abp.Authorization;
using Abp.Linq.Extensions;
using SixMan.ChiMa.Domain.Interface;

namespace SixMan.ChiMa.Application.Category
{
    public class CategoryAppService : ApplicationService
        , ICategoryAppService
    {
        private ICategoryRepository _repository;

        public IAsyncQueryableExecuter AsyncQueryableExecuter { get; set; }
        protected virtual string GetPermissionName { get; set; }

        protected virtual string GetAllPermissionName { get; set; }

        protected virtual string CreatePermissionName { get; set; }

        protected virtual string UpdatePermissionName { get; set; }

        protected virtual string DeletePermissionName { get; set; }

        public CategoryAppService(ICategoryRepository repository) : base()
        {
            this._repository = repository;
        }

        public virtual async Task<CategoryDto> Get(CategoryDto input)
        {
            SetRepository(input.Category);

            CheckGetPermission();

            var entity = await GeCategoryDtoByIdAsync(input.Id);
            return MapToEntityDto(entity, input.Category);
        }

        public virtual async Task<PagedResultDto<CategoryDto>> GetAll(CategoryPagedAndSortedResultRequestDto input)
        {
            CheckGetAllPermission();

            var query = CreateFilteredQuery(input);

            var totalCount = await AsyncQueryableExecuter.CountAsync(query);

            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            var entities = await AsyncQueryableExecuter.ToListAsync(query);

            return new PagedResultDto<CategoryDto>(
                totalCount,
                entities.Select(e =>MapToEntityDto(e, input.Category)).ToList()
            );
        }

        public virtual async Task<CategoryDto> Create(CategoryDto input)
        {
            SetRepository(input.Category);

            CheckCreatePermission();

            var entity = MapToEntity(input);

            await _repository.InsertAsync(entity);
            await CurrentUnitOfWork.SaveChangesAsync();

            return MapToEntityDto(entity,input.Category);
        }

        public virtual async Task<CategoryDto> Update(CategoryDto input)
        {
            SetRepository(input.Category);

            CheckUpdatePermission();

            var entity = await GeCategoryDtoByIdAsync(input.Id);

            MapToEntity(input, entity);
            await CurrentUnitOfWork.SaveChangesAsync();

            return MapToEntityDto(entity, input.Category);
        }

        public virtual Task Delete(CategoryDto input)
        {
            SetRepository(input.Category);

            CheckDeletePermission();

            return _repository.DeleteAsync(input.Id);
        }

        protected virtual Task<ICategory> GeCategoryDtoByIdAsync(long id)
        {
            return _repository.GetAsync(id);
        }

  

        /// <summary>
        /// Should apply sorting if needed.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="input">The input.</param>
        protected virtual IQueryable<ICategory> ApplySorting(IQueryable<ICategory> query, CategoryPagedAndSortedResultRequestDto input)
        {
            //Try to sort query if available
            var sortInput = input as ISortedResultRequest;
            if (sortInput != null)
            {
                if (!sortInput.Sorting.IsNullOrWhiteSpace())
                {
                    return query.OrderBy(sortInput.Sorting);
                }
            }

            //IQueryable.Task requires sorting, so we should sort if Take will be used.
            if (input is ILimitedResultRequest)
            {
                return query.OrderByDescending(e => e.Code);
            }

            //No sorting
            return query;
        }

        /// <summary>
        /// Should apply paging if needed.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="input">The input.</param>
        protected virtual IQueryable<ICategory> ApplyPaging(IQueryable<ICategory> query, CategoryPagedAndSortedResultRequestDto input)
        {
            //Try to use paging if available
            var pagedInput = input as IPagedResultRequest;
            if (pagedInput != null)
            {
                return query.PageBy(pagedInput);
            }

            //Try to limit query result if available
            var limitedInput = input as ILimitedResultRequest;
            if (limitedInput != null)
            {
                return query.Take(limitedInput.MaxResultCount);
            }

            //No paging
            return query;
        }

        /// <summary>
        /// This method should create <see cref="IQueryable{CategoryDto}"/> based on given input.
        /// It should filter query if needed, but should not do sorting or paging.
        /// Sorting should be done in <see cref="ApplySorting"/> and paging should be done in <see cref="ApplyPaging"/>
        /// methods.
        /// </summary>
        /// <param name="input">The input.</param>
        protected virtual IQueryable<ICategory> CreateFilteredQuery(CategoryPagedAndSortedResultRequestDto input)
        {
            SetRepository(input.Category);
            return _repository.GetAll();
        }

       

        /// <summary>
        /// Maps <see cref="CategoryDto"/> to <see cref="CategoryDto"/>.
        /// It uses <see cref="IObjectMapper"/> by default.
        /// It can be overrided for custom mapping.
        /// </summary>
        protected virtual CategoryDto MapToEntityDto(ICategory entity,string category)
        {
            var dto = ObjectMapper.Map<CategoryDto>(entity);
            dto.Category = category;
            return dto;
        }

        /// <summary>
        /// Maps <see cref="CategoryDto"/> to <see cref="CategoryDto"/> to create a new entity.
        /// It uses <see cref="IObjectMapper"/> by default.
        /// It can be overrided for custom mapping.
        /// </summary>
        protected virtual ICategory MapToEntity(CategoryDto createInput)
        {
            return ObjectMapper.Map<CategoryDto>(createInput);
        }

        /// <summary>
        /// Maps <see cref="CategoryDto"/> to <see cref="CategoryDto"/> to update the entity.
        /// It uses <see cref="IObjectMapper"/> by default.
        /// It can be overrided for custom mapping.
        /// </summary>
        protected virtual void MapToEntity(CategoryDto updateInput, ICategory entity)
        {
            ObjectMapper.Map(updateInput, entity);
        }

        protected virtual void CheckPermission(string permissionName)
        {
            if (!string.IsNullOrEmpty(permissionName))
            {
                PermissionChecker.Authorize(permissionName);
            }
        }

        protected virtual void CheckGetPermission()
        {
            CheckPermission(GetPermissionName);
        }

        protected virtual void CheckGetAllPermission()
        {
            CheckPermission(GetAllPermissionName);
        }

        protected virtual void CheckCreatePermission()
        {
            CheckPermission(CreatePermissionName);
        }

        protected virtual void CheckUpdatePermission()
        {
            CheckPermission(UpdatePermissionName);
        }

        protected virtual void CheckDeletePermission()
        {
            CheckPermission(DeletePermissionName);
        }

        public IFoodMaterialCategoryRepository FoodMaterialCategoryRepository { get; set; }

        private void SetRepository(string category)
        {
            //根据 category ,动态改变！
            _repository.Category = category;
        }
    }
}
