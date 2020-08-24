using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uibasoft.Smedia.Core.Entities;

namespace Uibasoft.Smedia.Core.Interfaces
{
    public interface IRepository<TElement> where TElement : BaseEntity
    {
        IEnumerable<TElement> GetAll();
        Task<TElement> GetById(int id);
        Task Add(TElement id);
        void Update(TElement id);
        Task Delete( int id);
    }
}
