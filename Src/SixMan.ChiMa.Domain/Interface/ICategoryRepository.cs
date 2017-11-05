using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Domain.Interface
{
    public interface ICategoryRepository
    {  
        Task InsertAsync(ICategory entity);
        Task DeleteAsync(long id);
        Task<ICategory> GetAsync(long id);
        IQueryable<ICategory> GetAll();

        string Category { get; set; } 
    }
}
