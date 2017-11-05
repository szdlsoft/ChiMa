using Abp.Domain.Repositories;
using SixMan.ChiMa.Domain.Food;
using SixMan.ChiMa.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixMan.ChiMa.EFCore.Repositorie
{
    public class CategoryRepository
        : ICategoryRepository
    {
        public string Category { get; set; }

        private IRepository<FoodMaterialCategory, long> _repository;

        public CategoryRepository(IRepository<FoodMaterialCategory, long> repository)
        {
            _repository = repository;
        }

        public Task DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ICategory> GetAll()
        {
            return _repository.GetAll();
        }

        public Task<ICategory> GetAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task InsertAsync(ICategory dto)
        {
            FoodMaterialCategory entity = new FoodMaterialCategory()
            {
                Code = dto.Code,
                Name = dto.Name
            };
            await _repository.InsertAsync(entity);
        }
    }
}
