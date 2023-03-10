using ItemManagement.Application.Interfaces.Repositories;
using ItemManagement.Domain.Models;
using ItemManagement.Infrastructure.Extensions.EfCore;
using Microsoft.EntityFrameworkCore;

namespace ItemManagement.Infrastructure.Repositories
{
    public class DictionaryStringIdRepository<TEntity> : IDictionaryStringIdRepository<TEntity> where TEntity : DictionaryStringIdEntity
    {
        protected readonly DataContext _context;

        public DictionaryStringIdRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<TEntity>> GetAll(DateTime? date)
        {
            if (date == null) date = DateTime.UtcNow;

            return await _context.Set<TEntity>()
                .Where(x => x.CreateDate <= date && (x.DeleteDate == null || x.DeleteDate >= date))
                .ToListAsync();
        }

        public async Task<TEntity> GetById(string itemId) =>
            await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == itemId);

        public async Task Add(TEntity entity)
        {
            entity.CreateDate = DateTime.UtcNow;
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(string itemId)
        {
            var itemToDelete = await _context.Set<TEntity>().Where(x => x.Id == itemId).FirstOrDefaultAsync();

            if (itemToDelete == null)
            {
                return;
            }

            itemToDelete.DeleteDate = DateTime.UtcNow;

            _context.Entry(itemToDelete).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public virtual async Task Update(TEntity entity)
        {
            var itemToUpdate = await _context.Set<TEntity>().Where(x => x.Id == entity.Id).FirstOrDefaultAsync();

            if (itemToUpdate == null)
            {
                return;
            }

            itemToUpdate.Name = entity.Name;

            _context.Entry(itemToUpdate).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task<List<TEntity>> GetByIds(List<string> itemsId) =>
            await _context.Set<TEntity>().Where(x => itemsId.Contains(x.Id)).ToListAsync();

        public async Task<List<TEntity>> GetBySentence(DateTime? date, string sentence)
        {
            if (date == null) date = DateTime.UtcNow;

            return await _context.Set<TEntity>()
                .Where(x => x.CreateDate <= date && (x.DeleteDate == null || x.DeleteDate >= date))
                .Where(x => x.Name.Contains(sentence, StringComparison.OrdinalIgnoreCase))
                .ToListAsync();
        }

        public async Task<TEntity> GetAdded(string itemId) =>
            await _context.Set<TEntity>().Where(x => x.Id == itemId).LastOrDefaultAsync();
    }
}