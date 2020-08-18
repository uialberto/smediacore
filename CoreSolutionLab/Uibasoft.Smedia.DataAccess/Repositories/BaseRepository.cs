using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uibasoft.Smedia.Core.Entities;
using Uibasoft.Smedia.Core.Interfaces;
using Uibasoft.Smedia.DataAccess.UnitOfWorks;

namespace Uibasoft.Smedia.DataAccess.Repositories
{
    public class BaseRepository<TElement> : IRepository<TElement> where TElement : BaseEntity
    {
        private readonly SmediaContext _context;
        private DbSet<TElement> _entities;
        public BaseRepository(SmediaContext context)
        {
            _context = context;
            _entities = context.Set<TElement>();

        }
        public async Task Add(TElement entity)
        {
            _entities.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            TElement entity = await  GetById(id);
            _entities.Remove(entity);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<TElement>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async Task<TElement> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task Update(TElement entity)
        {
            _entities.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
